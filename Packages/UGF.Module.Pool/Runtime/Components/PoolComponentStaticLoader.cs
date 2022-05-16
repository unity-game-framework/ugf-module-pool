using UGF.Module.Pool.Runtime.Assets;
using UGF.RuntimeTools.Runtime.Contexts;
using UnityEngine;

namespace UGF.Module.Pool.Runtime.Components
{
    public class PoolComponentStaticLoader<TComponent> : PoolComponentLoader<TComponent, PoolAssetStaticCollection<TComponent>, PoolAssetDescription> where TComponent : Component
    {
        public PoolComponentStaticLoader(PoolComponentLoaderDescription description) : base(description)
        {
        }

        protected override PoolAssetStaticCollection<TComponent> OnCollectionCreate(TComponent asset, PoolAssetDescription description, IContext context)
        {
            return new PoolAssetStaticCollection<TComponent>(asset, description.Count);
        }
    }
}
