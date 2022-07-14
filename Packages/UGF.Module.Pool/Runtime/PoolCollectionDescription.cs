using UGF.Description.Runtime;
using UGF.EditorTools.Runtime.Ids;

namespace UGF.Module.Pool.Runtime
{
    public class PoolCollectionDescription : DescriptionBase
    {
        public GlobalId AssetId { get; set; }
        public int InitialCount { get; set; }
    }
}
