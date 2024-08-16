using UnityEngine;

namespace UGF.Module.Pool.Runtime.Assets
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Pool/Pool Asset Dynamic Description", order = 2000)]
    public class PoolAssetDynamicDescriptionAsset : PoolAssetDescriptionAsset
    {
        [SerializeField] private bool m_expandEnable = true;
        [SerializeField] private int m_expandCount = 4;
        [SerializeField] private int m_expandThreshold;
        [SerializeField] private bool m_trimEnable = true;
        [SerializeField] private int m_trimCount = 4;
        [SerializeField] private int m_trimThreshold = 8;

        public bool ExpandEnable { get { return m_expandEnable; } set { m_expandEnable = value; } }
        public int ExpandCount { get { return m_expandCount; } set { m_expandCount = value; } }
        public int ExpandThreshold { get { return m_expandThreshold; } set { m_expandThreshold = value; } }
        public bool TrimEnable { get { return m_trimEnable; } set { m_trimEnable = value; } }
        public int TrimCount { get { return m_trimCount; } set { m_trimCount = value; } }
        public int TrimThreshold { get { return m_trimThreshold; } set { m_trimThreshold = value; } }

        protected override IPoolDescription OnBuild()
        {
            return new PoolAssetDynamicDescription(
                Loader,
                Asset,
                Count,
                Capacity,
                m_expandEnable,
                m_expandCount,
                m_expandThreshold,
                m_trimEnable,
                m_trimCount,
                m_trimThreshold
            );
        }
    }
}
