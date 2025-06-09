namespace OT_Performance_Tracer.classes
{
    internal class ThreadBlocks
    {
        public enum BlockTypes
        {
            None,
            Startup,
            Request,
            LogLevelChange,
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

        public List<(DateTime timeStamp, string level, string message)>? Parts = [];
        public string? Func;
        public string? Action;
        public string? objID;
        public string? Performer;
        public string? stats;
        public BlockTypes BlockType
        { get { return _type; } }

        public static readonly Dictionary<BlockTypes, string> BlockNames = new Dictionary<BlockTypes, string> {
            { BlockTypes.None, "None" },
            { BlockTypes.Startup, "Thread Startup"},
            { BlockTypes.Request, "Request"},
            { BlockTypes.LogLevelChange, "Log level changed"},
            { BlockTypes.Unkown, "Unkown"}
         };

        public static readonly Dictionary<BlockTypes, string> StartIDs = new Dictionary<BlockTypes, string>{
            { BlockTypes.None, ""},
            { BlockTypes.Startup, "OScript thread startup begins"},
            { BlockTypes.Request, "Processing Request on socket"},
            { BlockTypes.LogLevelChange, "Log level changed to"},
            { BlockTypes.Unkown, "Unkown"}
        };
    }
}