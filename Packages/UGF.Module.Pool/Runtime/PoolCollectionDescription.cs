using UGF.Description.Runtime;

namespace UGF.Module.Pool.Runtime
{
    public class PoolCollectionDescription : DescriptionBase
    {
        public string AssetId { get; set; }
        public int InitialCount { get; set; }
    }
}
