using System;
using UGF.Pool.Runtime;
using Object = UnityEngine.Object;

namespace UGF.Module.Pool.Runtime.Assets
{
    public class PoolAssetCycleCollection<TAsset> : PoolCollectionCycle<TAsset>, IPoolAssetCollection<TAsset> where TAsset : Object
    {
        public TAsset Asset { get; }

        public PoolAssetCycleCollection(TAsset asset, int capacity = 4) : base(capacity)
        {
            Asset = asset ? asset : throw new ArgumentNullException(nameof(asset));
        }
    }
}
