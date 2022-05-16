using UGF.Module.Pool.Runtime.Assets;
using UGF.RuntimeTools.Runtime.Contexts;
using UnityEngine;

namespace UGF.Module.Pool.Runtime.Components
{
    public class PoolComponentDynamicLoader<TComponent> : PoolComponentLoader<TComponent, PoolAssetDynamicCollection<TComponent>, PoolAssetDynamicDescription> where TComponent : Component
    {
        public PoolComponentDynamicLoader(PoolComponentLoaderDescription description) : base(description)
        {
        }

        protected override PoolAssetDynamicCollection<TComponent> OnCollectionCreate(TComponent asset, PoolAssetDynamicDescription description, IContext context)
        {
            return new PoolAssetDynamicCollection<TComponent>(asset, context, description.Capacity)
            {
                DefaultCount = description.Count,
                ExpandAuto = description.ExpandEnable,
                ExpandCount = description.ExpandCount,
                ExpandThreshold = description.ExpandThreshold,
                TrimAuto = description.TrimEnable,
                TrimCount = description.TrimCount,
                TrimThreshold = description.TrimThreshold
            };
        }
    }
}
