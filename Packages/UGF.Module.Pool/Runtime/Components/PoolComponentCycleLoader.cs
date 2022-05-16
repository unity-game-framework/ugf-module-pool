using UGF.Module.Pool.Runtime.Assets;
using UGF.RuntimeTools.Runtime.Contexts;
using UnityEngine;

namespace UGF.Module.Pool.Runtime.Components
{
    public class PoolComponentCycleLoader<TComponent> : PoolComponentLoader<TComponent, PoolAssetCycleCollection<TComponent>, PoolAssetDescription> where TComponent : Component
    {
        public PoolComponentCycleLoader(PoolComponentLoaderDescription description) : base(description)
        {
        }

        protected override PoolAssetCycleCollection<TComponent> OnCollectionCreate(TComponent asset, PoolAssetDescription description, IContext context)
        {
            return new PoolAssetCycleCollection<TComponent>(asset, description.Capacity);
        }
    }
}
