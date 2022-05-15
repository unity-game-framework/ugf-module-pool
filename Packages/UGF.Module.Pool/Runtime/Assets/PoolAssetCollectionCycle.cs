using System;
using UGF.Pool.Runtime;
using Object = UnityEngine.Object;

namespace UGF.Module.Pool.Runtime.Assets
{
    public class PoolAssetCollectionCycle<TAsset> : PoolCollectionCycle<TAsset> where TAsset : Object
    {
        public TAsset Asset { get; }

        public PoolAssetCollectionCycle(TAsset asset, int capacity = 4) : base(capacity)
        {
            Asset = asset ? asset : throw new ArgumentNullException(nameof(asset));
        }
    }
}
