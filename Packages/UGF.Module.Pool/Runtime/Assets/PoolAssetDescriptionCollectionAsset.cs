using System.Collections.Generic;
using UGF.EditorTools.Runtime.Assets;
using UGF.EditorTools.Runtime.Ids;
using UnityEngine;

namespace UGF.Module.Pool.Runtime.Assets
{
    public class PoolAssetDescriptionCollectionAsset : PoolDescriptionCollectionAsset
    {
        [AssetId(typeof(PoolLoaderAsset))]
        [SerializeField] private GlobalId m_loader;
        [SerializeField] private int m_count = 4;
        [SerializeField] private int m_capacity = 4;
        [AssetId]
        [SerializeField] private List<GlobalId> m_assets = new List<GlobalId>();

        public GlobalId Loader { get { return m_loader; } set { m_loader = value; } }
        public int Count { get { return m_count; } set { m_count = value; } }
        public int Capacity { get { return m_capacity; } set { m_capacity = value; } }
        public List<GlobalId> Assets { get { return m_assets; } }

        protected override void OnGetDescriptions(IDictionary<GlobalId, IPoolDescription> descriptions)
        {
            for (int i = 0; i < m_assets.Count; i++)
            {
                GlobalId assetId = m_assets[i];

                var description = new PoolAssetDescription
                {
                    LoaderId = m_loader,
                    AssetId = assetId,
                    Count = m_count,
                    Capacity = m_capacity
                };

                descriptions.Add(default, description);
            }
        }
    }
}
