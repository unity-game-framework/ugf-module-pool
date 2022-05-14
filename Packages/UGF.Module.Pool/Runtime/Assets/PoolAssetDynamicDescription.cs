namespace UGF.Module.Pool.Runtime.Assets
{
    public class PoolAssetDynamicDescription : PoolAssetDescription
    {
        public int DefaultCount { get; set; } = 4;
        public bool ExpandEnable { get; set; } = true;
        public int ExpandCount { get; set; } = 4;
        public int ExpandThreshold { get; set; } = 0;
        public bool TrimEnable { get; set; } = true;
        public int TrimCount { get; set; } = 4;
        public int TrimThreshold { get; set; } = 8;
    }
}
