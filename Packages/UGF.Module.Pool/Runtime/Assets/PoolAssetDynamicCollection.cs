using UGF.Pool.Runtime.Unity;
using UGF.RuntimeTools.Runtime.Contexts;
using UnityEngine;

namespace UGF.Module.Pool.Runtime.Assets
{
    public class PoolAssetDynamicCollection<TAsset> : PoolCollectionDynamicObject<TAsset>, IPoolAssetCollection<TAsset> where TAsset : Object
    {
        public TAsset Asset { get { return Source; } }

        public PoolAssetDynamicCollection(TAsset source, IContext context, int capacity = 4) : base(source, context, capacity)
        {
        }
    }
}
