namespace UGF.Module.Pool.Runtime.Assets
{
    public class PoolAssetDynamicDescription : PoolAssetDescription
    {
        public bool ExpandEnable { get; set; }
        public int ExpandCount { get; set; }
        public int ExpandThreshold { get; set; }
        public bool TrimEnable { get; set; }
        public int TrimCount { get; set; }
        public int TrimThreshold { get; set; }
    }
}
