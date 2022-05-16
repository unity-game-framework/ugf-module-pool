using UGF.Module.Pool.Runtime.Assets;
using UGF.RuntimeTools.Runtime.Contexts;
using UnityEngine;

namespace UGF.Module.Pool.Runtime.Components
{
    public class PoolComponentCycleLoader<TComponent> : PoolAssetCycleLoader<TComponent> where TComponent : Component
    {
        protected override void OnCollectionDestroy(PoolAssetCycleCollection<TComponent> collection, PoolAssetDescription description, IContext context)
        {
            PoolComponentUtility.CollectionDestroy(collection);
        }
    }
}
