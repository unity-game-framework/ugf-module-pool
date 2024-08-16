using System;
using UGF.EditorTools.Runtime.Ids;

namespace UGF.Module.Pool.Runtime.Assets
{
    public class PoolAssetDescription : PoolDescription
    {
        public GlobalId AssetId { get; }
        public int Count { get; }
        public int Capacity { get; }

        public PoolAssetDescription(
            GlobalId loaderId,
            GlobalId assetId,
            int count,
            int capacity) : base(loaderId)
        {
            if (!assetId.IsValid()) throw new ArgumentException("Value should be valid.", nameof(assetId));
            if (count < 0) throw new ArgumentOutOfRangeException(nameof(count));
            if (capacity < 0) throw new ArgumentOutOfRangeException(nameof(capacity));

            AssetId = assetId;
            Count = count;
            Capacity = capacity;
        }
    }
}
