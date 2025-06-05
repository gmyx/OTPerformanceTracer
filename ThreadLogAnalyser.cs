using OT_Performance_Tracer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OT_Performance_Tracer.ThreadBlocks;

namespace OT_Performance_Tracer
{
    internal class ThreadLogAnalyser
    {

        private readonly string _filename;
        private string[]? _data = [];
        private Dictionary<int, ThreadBlocks> _blocks;
        public ThreadLogAnalyser(string filename) {
            _filename = filename;
            _blocks = [];

            //could should be loaded async - but not right now
        }

        public bool LoadFile()
        {
            //open the log file
            _data = File.ReadAllLines(_filename);

            //line one should start with thread starup
            if (_data[0].Contains("OScript thread startup begin") == false) return false;

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

            ThreadBlocks? currentBlock = null;
            DateTime previousDT = DateTime.MinValue;
            int blockCount = 0;
            string blockName = Path.GetFileNameWithoutExtension(_filename);

            foreach (string line in _data)
            {
                foreach (KeyValuePair<BlockTypes, string> StartID in ThreadBlocks.StartIDs)
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
                        ThreadBlocks oldBlock = currentBlock!;
                        currentBlock = new ThreadBlocks(StartID.Key);

                        //if block is a request block, one line from previous block belongs here
                        if (StartID.Key == BlockTypes.Request)
                        {
                            (DateTime timeStamp, string message) lastLine = oldBlock.Parts!.Last();
                            oldBlock.Parts!.Remove(lastLine);

                            //add it current block
                            currentBlock.Parts!.Add(lastLine);
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
                } else if (line.Contains("objId = "))
                {
                    currentBlock!.objID = line.Split(" = ")[1];
                }
                else if (line.Contains("objAction = "))
                {
                    currentBlock!.Action = line.Split(" = ")[1];
                }

                //add this line
                currentBlock!.Parts!.Add(value);                
            }

            //clean up any remaining data
            if (currentBlock != null)
            {
                _blocks.Add(blockCount, currentBlock);
            }
            
        }

        public Dictionary<int, ThreadBlocks> Blocks { get { return _blocks; } }
    }
}
