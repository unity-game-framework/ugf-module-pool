using UGF.Module.Pool.Runtime.Assets;
using UGF.RuntimeTools.Runtime.Contexts;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UGF.Module.Pool.Runtime.Components
{
    public class PoolComponentDynamicLoader<TComponent> : PoolComponentLoader<TComponent, PoolComponentDynamicCollection<TComponent>, PoolAssetDynamicDescription> where TComponent : Component
    {
        public PoolComponentDynamicLoader(PoolComponentLoaderDescription description) : base(description)
        {
        }

        protected override PoolComponentDynamicCollection<TComponent> OnCollectionCreate(TComponent asset, PoolAssetDynamicDescription description, IContext context)
        {
            Scene scene = PoolComponentUtility.GetOrCreateScene(Description.SceneName);

            return new PoolComponentDynamicCollection<TComponent>(asset, scene, context, description.Capacity)
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
