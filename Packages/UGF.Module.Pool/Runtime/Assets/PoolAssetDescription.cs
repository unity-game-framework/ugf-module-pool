using UGF.EditorTools.Runtime.Ids;

namespace UGF.Module.Pool.Runtime.Assets
{
    public class PoolAssetDescription : PoolDescription
    {
        public GlobalId AssetId { get; set; }
        public int Count { get; set; }
        public int Capacity { get; set; }
    }
}
