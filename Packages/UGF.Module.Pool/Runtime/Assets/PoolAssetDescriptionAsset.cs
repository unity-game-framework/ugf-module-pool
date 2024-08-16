using UGF.EditorTools.Runtime.Assets;
using UGF.EditorTools.Runtime.Ids;
using UnityEngine;

namespace UGF.Module.Pool.Runtime.Assets
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Pool/Pool Asset Description", order = 2000)]
    public class PoolAssetDescriptionAsset : PoolDescriptionAsset
    {
        [AssetId(typeof(Object))]
        [SerializeField] private Hash128 m_asset;
        [SerializeField] private int m_count = 4;
        [SerializeField] private int m_capacity = 4;

        public GlobalId Asset { get { return m_asset; } set { m_asset = value; } }
        public int Count { get { return m_count; } set { m_count = value; } }
        public int Capacity { get { return m_capacity; } set { m_capacity = value; } }

        protected override IPoolDescription OnBuild()
        {
            return new PoolAssetDescription(
                Loader,
                m_asset,
                m_count,
                m_capacity
            );
        }
    }
}
