using System;
using UGF.Pool.Runtime;
using Object = UnityEngine.Object;

namespace UGF.Module.Pool.Runtime.Assets
{
    public class PoolAssetStaticCollection<TAsset> : PoolCollection<TAsset>, IPoolAssetCollection<TAsset> where TAsset : Object
    {
        public TAsset Asset { get; }

        public PoolAssetStaticCollection(TAsset asset, int capacity = 4) : base(capacity)
        {
            Asset = asset ? asset : throw new ArgumentNullException(nameof(asset));
        }

        public void BuildAll(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Add(Object.Instantiate(Asset));
            }
        }

        public void DestroyAll()
        {
            while (Count > 0)
            {
                Object.Destroy(GetAny());
            }
        }
    }
}
