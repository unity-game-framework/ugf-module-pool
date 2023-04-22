using System.Collections.Generic;
using UGF.Application.Runtime;
using UGF.EditorTools.Runtime.Assets;
using UGF.EditorTools.Runtime.Ids;
using UnityEngine;

namespace UGF.Module.Pool.Runtime
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Pool/Pool Module", order = 2000)]
    public class PoolModuleAsset : ApplicationModuleAsset<PoolModule, PoolModuleDescription>
    {
        [SerializeField] private bool m_unloadOnUninitialize = true;
        [SerializeField] private List<AssetIdReference<PoolLoaderAsset>> m_loaders = new List<AssetIdReference<PoolLoaderAsset>>();
        [SerializeField] private List<AssetIdReference<PoolDescriptionAsset>> m_pools = new List<AssetIdReference<PoolDescriptionAsset>>();
        [SerializeField] private List<PoolDescriptionCollectionAsset> m_collections = new List<PoolDescriptionCollectionAsset>();
        [AssetId(typeof(PoolDescriptionAsset))]
        [SerializeField] private List<GlobalId> m_preload = new List<GlobalId>();
        [AssetId(typeof(PoolDescriptionAsset))]
        [SerializeField] private List<GlobalId> m_preloadAsync = new List<GlobalId>();

        public bool UnloadOnUninitialize { get { return m_unloadOnUninitialize; } set { m_unloadOnUninitialize = value; } }
        public List<AssetIdReference<PoolLoaderAsset>> Loaders { get { return m_loaders; } }
        public List<AssetIdReference<PoolDescriptionAsset>> Pools { get { return m_pools; } }
        public List<PoolDescriptionCollectionAsset> Collections { get { return m_collections; } set { m_collections = value; } }
        public List<GlobalId> Preload { get { return m_preload; } }
        public List<GlobalId> PreloadAsync { get { return m_preloadAsync; } }

        protected override IApplicationModuleDescription OnBuildDescription()
        {
            var description = new PoolModuleDescription
            {
                RegisterType = typeof(PoolModule),
                UnloadOnUninitialize = m_unloadOnUninitialize
            };

            for (int i = 0; i < m_loaders.Count; i++)
            {
                AssetIdReference<PoolLoaderAsset> reference = m_loaders[i];

                description.Loaders.Add(reference.Guid, reference.Asset);
            }

            for (int i = 0; i < m_pools.Count; i++)
            {
                AssetIdReference<PoolDescriptionAsset> reference = m_pools[i];

                description.Pools.Add(reference.Guid, reference.Asset.Build());
            }

            for (int i = 0; i < m_collections.Count; i++)
            {
                PoolDescriptionCollectionAsset collection = m_collections[i];

                collection.GetDescriptions(description.Pools);
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
