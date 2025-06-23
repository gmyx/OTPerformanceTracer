using System.Linq;
using static OT_Performance_Tracer.classes.ThreadBlocks;

namespace OT_Performance_Tracer.classes
{
    internal class ThreadLogAnalyser
    {
        private readonly string _filename;
        private string[]? _data = [];
        private Dictionary<int, ThreadBlocks> _blocks;

        private List<string> falsePositives = [
            "KFilePrefs::GetKFilePrefs - sharing loaded pref:",
            "Going to raise it to the INFO level during startup",
            "ResetLog(): Changing log level from 2 to 0"
        ];

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

        private static (DateTime timeStamp, string level, string message) SplitParts(string line)
        {
            if (line.Length < 19) throw new Exception("Bad date format");

            //currently supported format:
            //  MM/DD/YYYY HH:MM:SS
            string datePart = line[..19]; //sloppy
            DateTime dOut;
            if (DateTime.TryParse(datePart, out dOut) == false) throw new Exception("Bad date format");

            //now get the next part - the log level
            //curretly known - DEBUG, INFO, WARN, ERROR
            string level = ";";
            string message = "";

            //some lines may be truncated, so can't get a level or details
            if (line.Length < 24)
            {
                message = line[20..];
            }
            else
            {
                level = line[20..][..5].Trim(); //doesn't seem right, but errors with a negative
                if (line.Length > 24)
                {
                    message = line[25..].Trim(); //there are lines of just INFO and nothing else
                }
            }

            return (dOut, level, message);
        }

        private string filterQuotes(string message)
        {
            if (message.Length < 2) return message;
            if (message.StartsWith('\'') == false) return message;
            if (message.EndsWith('\'') == false) return message;
            return message[1..][..^1];
        }

        public void AnalyseFile()
        {
            //go each line at a time and find different blocks
            if (_data is null) return; //shoudl throw an exeption instead

            ThreadBlocks? currentBlock = new(BlockTypes.Unkown);
            DateTime previousDT = DateTime.MinValue;
            string previousLevel = "";
            int blockCount = 0;
            string blockName = Path.GetFileNameWithoutExtension(_filename);
            bool foundDebug = false; //not my prefered way, but works

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

                        //if block is a request block, one line from previous block belongs here, sometimes
                        if ((StartID.Key == BlockTypes.Request || StartID.Key == BlockTypes.LogLevelChange) && foundDebug == true)
                        {
                            //depends on the previous line
                            (DateTime timeStamp, string level, string message) lastLine = _blocks[blockCount - 1].Parts!.Last();
                            _blocks[blockCount - 1].Parts!.Remove(_blocks[blockCount - 1].Parts!.Last());

                            //avoid false positives
                            if (falsePositives.Any(item => lastLine.message.Contains(item)) == false)
                            {
                                //add it current block
                                currentBlock.Parts!.Add(lastLine);
                            } // else just drop it if debug
                            else if (lastLine.level == "DEBUG")
                            {
                                //add it current block
                                //currentBlock.Parts!.Add(lastLine);
                            }
                        }
                    }
                }

                //add the line to the current block
                (DateTime timeStamp, string level, string message) value;

                //may not start with a datestamp, such as when outputing WebReports
                try
                {
                    //try to split the parts, if it fails, did not start with a date
                    value = SplitParts(line);
                    previousDT = value.timeStamp;
                    previousLevel = value.level;
                    if (value.level == "DEBUG") foundDebug = true;
                }
                catch (Exception e)
                {
                    if (e.Message != "Bad date format")
                    {
                        //rethrow error
                        throw;
                    }

                    value = (previousDT, previousLevel, line);
                }

                //see if line contains a portion we want
                if (line.Contains("func = ", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (currentBlock!.Func == "" || currentBlock!.Func == null) currentBlock!.Func = filterQuotes(line.Split(" = ")[1]);
                }
                if (line.Contains("path_info = ", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (currentBlock!.Func == "" || currentBlock!.Func == null) currentBlock!.Func = filterQuotes(line.Split(" = ")[1]);
                }
                else if (line.Contains("objId = ", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (currentBlock!.objID == "" || currentBlock!.objID == null) currentBlock!.objID = filterQuotes(line.Split(" = ")[1]);
                }
                else if (line.Contains("HTTP_REFERER = ", StringComparison.InvariantCultureIgnoreCase))
                {
                    //alternative to func. may have objID, may have objAction
                    string[] lineParts = line.Split(new char[] { '=', '?', '&' });

                    //now do each subpart seperatly
                    for (int indexer = 0; indexer < lineParts.Length; indexer++)
                    {
                        if (lineParts[indexer].Contains('%')) continue; //most licky nexturl, ignore
                        if (lineParts[indexer].Contains("func", StringComparison.InvariantCultureIgnoreCase))
                        {
                            if (currentBlock!.Func == "" || currentBlock!.Func == null) currentBlock!.Func = filterQuotes(lineParts[indexer + 1]);
                        }
                        else if (lineParts[indexer].Contains("objid", StringComparison.InvariantCultureIgnoreCase))
                        {
                            if (currentBlock!.objID == "" || currentBlock!.objID == null) currentBlock!.objID = filterQuotes(lineParts[indexer + 1]);
                        }
                        else if (lineParts[indexer].Contains("objAction", StringComparison.InvariantCultureIgnoreCase))
                        {
                            if (currentBlock!.Action == "" || currentBlock!.Action == null) currentBlock!.Action = filterQuotes(lineParts[indexer + 1]);
                        }
                    }
                }
                else if (line.Contains("objAction = ", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (currentBlock!.Action == "" || currentBlock!.Action == null) currentBlock!.Action = filterQuotes(line.Split(" = ")[1]);
                }
                else if (line.Contains("A<1,0,'__ExecutionHandler'", StringComparison.InvariantCultureIgnoreCase))
                {
                    //this is the stats block
                    currentBlock!.stats = value.message;
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
                //unless
                //this is the one we want to surpress
                _blocks.Last().Value.Parts!.Remove(_blocks.Last().Value.Parts!.Last());
            }
        }

        public Dictionary<int, ThreadBlocks> Blocks
        { get { return _blocks; } }
    }
}