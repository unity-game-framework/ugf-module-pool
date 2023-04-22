using System.Collections.Generic;
using UGF.EditorTools.Runtime.Assets;
using UGF.EditorTools.Runtime.Ids;
using UnityEngine;

namespace UGF.Module.Pool.Runtime
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Pool/Pool Description Collection List", order = 2000)]
    public class PoolDescriptionCollectionListAsset : PoolDescriptionCollectionAsset
    {
        [SerializeField] private List<AssetIdReference<PoolDescriptionAsset>> m_pools = new List<AssetIdReference<PoolDescriptionAsset>>();

        public List<AssetIdReference<PoolDescriptionAsset>> Pools { get { return m_pools; } }

        protected override void OnGetDescriptions(IDictionary<GlobalId, IPoolDescription> descriptions)
        {
            for (int i = 0; i < m_pools.Count; i++)
            {
                AssetIdReference<PoolDescriptionAsset> reference = m_pools[i];

                descriptions.Add(reference.Guid, reference.Asset.Build());
            }
        }
    }
}
