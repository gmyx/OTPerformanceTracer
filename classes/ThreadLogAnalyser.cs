using static OT_Performance_Tracer.classes.ThreadBlocks;

namespace OT_Performance_Tracer.classes
{
    internal class ThreadLogAnalyser
    {
        private readonly string _filename;
        private string[]? _data = [];
        private Dictionary<int, ThreadBlocks> _blocks;

        public ThreadLogAnalyser(string filename)
        {
            _filename = filename;
            _blocks = [];

            //could should be loaded async - but not right now
        }

        public bool LoadFile()
        {
            //open the log file
            _data = File.ReadAllLines(_filename);

            //look for thread startup in first few lines. if log level is debug, will not be first
            bool found = false;
            for (int indexer = 0; indexer < 100; indexer++)
            {
                if (_data.Length > indexer)
                {
                    if (_data[indexer].Contains("OScript thread startup begin"))
                    {
                        found = true;
                        break;
                    }
                }
            }

            if (found == false) return false;

            //this fails if thread logs are highter than info, need to read a few lines
            //if (_data[0].Contains("OScript thread startup begin") == false) return false;

            return true;
        }

        private static (DateTime timeStamp, string message) SplitParts(string line)
        {
            if (line.Length < 19) throw new Exception("Bad date format");

            //currently supported format:
            //  MM/DD/YYYY HH:MM:SS
            string datePart = line[..19]; //sloppy
            DateTime dOut;
            if (DateTime.TryParse(datePart, out dOut) == false) throw new Exception("Bad date format");

            return (dOut, line[20..]); // we will want to parse the log level as well, later
        }

        public void AnalyseFile()
        {
            //go each line at a time and find different blocks
            if (_data is null) return; //shoudl throw an exeption instead

            ThreadBlocks? currentBlock = new(BlockTypes.Unkown);
            DateTime previousDT = DateTime.MinValue;
            int blockCount = 0;
            string blockName = Path.GetFileNameWithoutExtension(_filename);

            foreach (string line in _data)
            {
                foreach (KeyValuePair<BlockTypes, string> StartID in StartIDs)
                {
                    if (StartID.Value != "" && line.Contains(StartID.Value))
                    {
                        //if currentBlock is not null, then close out previous block, add it to the pile
                        if (currentBlock != null)
                        {
                            _blocks.Add(blockCount, currentBlock);
                            blockCount++;
                        }

                        //create a new block
                        //ThreadBlocks oldBlock = currentBlock!;
                        currentBlock = new ThreadBlocks(StartID.Key);

                        //if block is a request block, one line from previous block belongs here                        
                        if (StartID.Key == BlockTypes.Request || StartID.Key == BlockTypes.LogLevelChange)
                        {
                            //depends on the previous line                            
                            (DateTime timeStamp, string message) lastLine = _blocks[blockCount - 1].Parts!.Last();
                            _blocks[blockCount - 1].Parts!.Remove(_blocks[blockCount - 1].Parts!.Last()); 

                            if (lastLine.message.Contains("DEBUG KFilePrefs::GetKFilePrefs - sharing loaded pref:") == false)
                            {                            
                                //add it current block
                                currentBlock.Parts!.Add(lastLine);
                            } // else just drop it
                        }
                    }
                }

                //add the line to the current block
                (DateTime timeStamp, string message) value;

                //may not start with a datestamp, such as when outputing WebReports
                try
                {
                    //try to split the parts, if it fails, did not start with a date
                    value = SplitParts(line);
                    previousDT = value.timeStamp;
                }
                catch (Exception e)
                {
                    if (e.Message != "Bad date format")
                    {
                        //rethrow error
                        throw;
                    }

                    value = (previousDT, line);
                }

                //see if line contains a portion we want
                if (line.Contains("func = "))
                {
                    currentBlock!.Func = line.Split(" = ")[1];
                }
                else if (line.Contains("objId = "))
                {
                    currentBlock!.objID = line.Split(" = ")[1];
                }
                else if (line.Contains("objAction = "))
                {
                    currentBlock!.Action = line.Split(" = ")[1];
                }
                else if (line.Contains("A<1,0,'__ExecutionHandler'"))
                {
                    //this is the stats block
                    currentBlock!.stats = line;
                }

                //add this line
                currentBlock!.Parts!.Add(value);
            }

            //clean up any remaining data
            if (currentBlock != null)
            {
                _blocks.Add(blockCount, currentBlock);
            }

            //first block is 'unkown', but could be empty. if empty, delete
            if (_blocks[0].Parts!.Count == 0)
            {
                _blocks.Remove(0);
            }

            //last line of file could be a late log, causing issue... delete it
            if (_blocks.Last().Value.Parts!.Last().message.Contains("FilePrefs::GetKFilePrefs - sharing loaded pref"))
            {
                //this is the one we want to surpress
                _blocks.Last().Value.Parts!.Remove(_blocks.Last().Value.Parts!.Last());
            }
        }

        public Dictionary<int, ThreadBlocks> Blocks
        { get { return _blocks; } }
    }
}