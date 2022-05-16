using UGF.EditorTools.Runtime.IMGUI.Attributes;
using UnityEngine;

namespace UGF.Module.Pool.Runtime.Assets
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Pool/Pool Asset Description", order = 2000)]
    public class PoolAssetDescriptionAsset : PoolDescriptionAsset
    {
        [AssetGuid(typeof(Object))]
        [SerializeField] private string m_asset;
        [SerializeField] private int m_count = 4;
        [SerializeField] private int m_capacity = 4;

        public string Asset { get { return m_asset; } set { m_asset = value; } }
        public int Count { get { return m_count; } set { m_count = value; } }
        public int Capacity { get { return m_capacity; } set { m_capacity = value; } }

        protected override IPoolDescription OnBuild()
        {
            return new PoolAssetDescription
            {
                LoaderId = Loader,
                AssetId = m_asset,
                Count = m_count,
                Capacity = m_capacity
            };
        }
    }
}
