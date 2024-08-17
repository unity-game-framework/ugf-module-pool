using System;
using UGF.EditorTools.Runtime.Ids;

namespace UGF.Module.Pool.Runtime.Assets
{
    public class PoolAssetDynamicDescription : PoolAssetDescription
    {
        public bool ExpandEnable { get; }
        public int ExpandCount { get; }
        public int ExpandThreshold { get; }
        public bool TrimEnable { get; }
        public int TrimCount { get; }
        public int TrimThreshold { get; }

        public PoolAssetDynamicDescription(
            GlobalId loaderId,
            GlobalId assetId,
            int count,
            int capacity,
            bool expandEnable,
            int expandCount,
            int expandThreshold,
            bool trimEnable,
            int trimCount,
            int trimThreshold) : base(loaderId, assetId, count, capacity)
        {
            if (expandCount < 0) throw new ArgumentOutOfRangeException(nameof(expandCount));
            if (expandThreshold < 0) throw new ArgumentOutOfRangeException(nameof(expandThreshold));
            if (trimCount < 0) throw new ArgumentOutOfRangeException(nameof(trimCount));
            if (trimThreshold < 0) throw new ArgumentOutOfRangeException(nameof(trimThreshold));

            ExpandEnable = expandEnable;
            ExpandCount = expandCount;
            ExpandThreshold = expandThreshold;
            TrimEnable = trimEnable;
            TrimCount = trimCount;
            TrimThreshold = trimThreshold;
        }
    }
}
