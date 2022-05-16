using UGF.Module.Pool.Runtime.Assets;
using UGF.RuntimeTools.Runtime.Contexts;
using UnityEngine;

namespace UGF.Module.Pool.Runtime.Components
{
    public class PoolComponentDynamicLoader<TComponent> : PoolAssetDynamicLoader<TComponent> where TComponent : Component
    {
        protected override void OnCollectionDestroy(PoolAssetDynamicCollection<TComponent> collection, PoolAssetDynamicDescription description, IContext context)
        {
            PoolComponentUtility.CollectionDestroy(collection);
        }
    }
}
