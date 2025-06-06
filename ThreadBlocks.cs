using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OT_Performance_Tracer
{
    internal class ThreadBlocks
    {
        public enum BlockTypes
        {
            None,
            Startup,
            Request,
            Unkown
        }
        private BlockTypes _type;
        public ThreadBlocks()
        {
            _type = BlockTypes.None;
        }
        public ThreadBlocks(BlockTypes type)
        {
            _type = type;
        }

        public List<(DateTime timeStamp, string message)>? Parts = [];
        public string Func;
        public string Action;
        public string objID;
        public string Performer;
        public BlockTypes BlockType { get { return _type; } }

        public readonly static Dictionary<BlockTypes, string> BlockNames = new Dictionary<BlockTypes, string> {
            { BlockTypes.None, "None" },
            { BlockTypes.Startup, "Thread Startup"},
            { BlockTypes.Request, "Request"},
            { BlockTypes.Unkown, "Unkown"}
         };
        public readonly static Dictionary<BlockTypes, string> StartIDs = new Dictionary<BlockTypes, string>{
            { BlockTypes.None, ""},
            { BlockTypes.Startup, "OScript thread startup begins"},
            { BlockTypes.Request, "Processing Request on socket"},
            { BlockTypes.Unkown, "Unkown"}
        };
        public readonly static Dictionary<BlockTypes, string> EndIDs = new Dictionary<BlockTypes, string>{
            { BlockTypes.None, ""},
            { BlockTypes.Startup, "OScript thread startup finished"},
            { BlockTypes.Request, "Done with Request on socket" },
            { BlockTypes.Unkown, "Unkown"}
        };
    }
}
