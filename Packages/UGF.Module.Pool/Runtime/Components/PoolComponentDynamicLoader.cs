using UGF.Module.Pool.Runtime.Assets;
using UGF.RuntimeTools.Runtime.Contexts;
using UnityEngine;

namespace UGF.Module.Pool.Runtime.Components
{
    public class PoolComponentDynamicLoader<TComponent> : PoolComponentLoader<TComponent, PoolComponentDynamicCollection<TComponent>, PoolAssetDynamicDescription> where TComponent : Component
    {
        protected override PoolComponentDynamicCollection<TComponent> OnCreateCollection(TComponent asset, PoolAssetDynamicDescription description, IContext context)
        {
            return new PoolComponentDynamicCollection<TComponent>(asset, context, description.Capacity)
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
