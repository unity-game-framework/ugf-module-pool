using System.Collections.Generic;
using UGF.Application.Runtime;
using UGF.EditorTools.Runtime.IMGUI.AssetReferences;
using UnityEngine;

namespace UGF.Module.Pool.Runtime
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Pool/Pool Module", order = 2000)]
    public class PoolModuleAsset : ApplicationModuleAsset<PoolModule, PoolModuleDescription>
    {
        [SerializeField] private bool m_unloadOnUninitialize = true;
        [SerializeField] private List<AssetReference<PoolDescriptionAsset>> m_pools = new List<AssetReference<PoolDescriptionAsset>>();
        [SerializeField] private List<AssetReference<PoolLoaderAsset>> m_loaders = new List<AssetReference<PoolLoaderAsset>>();
        [SerializeField] private List<string> m_preload = new List<string>();
        [SerializeField] private List<string> m_preloadAsync = new List<string>();

        public bool UnloadOnUninitialize { get { return m_unloadOnUninitialize; } set { m_unloadOnUninitialize = value; } }
        public List<AssetReference<PoolDescriptionAsset>> Pools { get { return m_pools; } }
        public List<AssetReference<PoolLoaderAsset>> Loaders { get { return m_loaders; } }
        public List<string> Preload { get { return m_preload; } }
        public List<string> PreloadAsync { get { return m_preloadAsync; } }

        protected override IApplicationModuleDescription OnBuildDescription()
        {
            var description = new PoolModuleDescription
            {
                RegisterType = typeof(PoolModule),
                UnloadOnUninitialize = m_unloadOnUninitialize
            };

            for (int i = 0; i < m_pools.Count; i++)
            {
                AssetReference<PoolDescriptionAsset> reference = m_pools[i];

                description.Pools.Add(reference.Guid, reference.Asset.Build());
            }

            for (int i = 0; i < m_loaders.Count; i++)
            {
                AssetReference<PoolLoaderAsset> reference = m_loaders[i];

                description.Loaders.Add(reference.Guid, reference.Asset);
            }

            for (int i = 0; i < m_preload.Count; i++)
            {
                description.Preload.Add(m_preload[i]);
            }

            for (int i = 0; i < m_preloadAsync.Count; i++)
            {
                description.PreloadAsync.Add(m_preloadAsync[i]);
            }

            return description;
        }

        protected override PoolModule OnBuild(PoolModuleDescription description, IApplication application)
        {
            return new PoolModule(description, application);
        }
    }
}
