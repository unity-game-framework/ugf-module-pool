using System;
using UGF.Description.Runtime;
using UGF.EditorTools.Runtime.Ids;

namespace UGF.Module.Pool.Runtime
{
    public class PoolCollectionDescription : DescriptionBase
    {
        public GlobalId AssetId { get; }
        public int InitialCount { get; }

        public PoolCollectionDescription(GlobalId assetId, int initialCount)
        {
            if (!assetId.IsValid()) throw new ArgumentException("Value should be valid.", nameof(assetId));
            if (initialCount < 0) throw new ArgumentOutOfRangeException(nameof(initialCount));

            AssetId = assetId;
            InitialCount = initialCount;
        }
    }
}
