using UGF.Module.Pool.Runtime.Assets;
using UGF.RuntimeTools.Runtime.Contexts;
using UnityEngine;

namespace UGF.Module.Pool.Runtime.GameObjects
{
    public class PoolGameObjectDynamicLoader<TComponent> : PoolGameObjectLoader<TComponent, PoolGameObjectDynamicCollection<TComponent>, PoolAssetDynamicDescription> where TComponent : Component
    {
        protected override PoolGameObjectDynamicCollection<TComponent> OnCreateCollection(TComponent asset, PoolAssetDynamicDescription description, IContext context)
        {
            return new PoolGameObjectDynamicCollection<TComponent>(asset, context, description.Capacity)
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
