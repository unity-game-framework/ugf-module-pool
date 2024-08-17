using System;
using UGF.EditorTools.Runtime.Assets;
using UGF.EditorTools.Runtime.Ids;
using UnityEngine;
using Object = UnityEngine.Object;

namespace UGF.Module.Pool.Runtime.Assets
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Pool/Pool Asset Dynamic Description Table", order = 2000)]
    public class PoolAssetDynamicDescriptionTableAsset : PoolDescriptionTableAsset<PoolAssetDynamicDescriptionTableAsset.Entry, PoolAssetDynamicDescription>
    {
        [Serializable]
        public struct Entry : IPoolDescriptionTableEntry<PoolAssetDynamicDescription>
        {
            [SerializeField] private Hash128 m_id;
            [SerializeField] private string m_name;
            [AssetId(typeof(PoolLoaderAsset))]
            [SerializeField] private Hash128 m_loader;
            [AssetId(typeof(Object))]
            [SerializeField] private Hash128 m_asset;
            [SerializeField] private int m_count;
            [SerializeField] private int m_capacity;
            [SerializeField] private bool m_expandEnable;
            [SerializeField] private int m_expandCount;
            [SerializeField] private int m_expandThreshold;
            [SerializeField] private bool m_trimEnable;
            [SerializeField] private int m_trimCount;
            [SerializeField] private int m_trimThreshold;

            public GlobalId Id { get { return m_id; } set { m_id = value; } }
            public string Name { get { return m_name; } set { m_name = value; } }
            public GlobalId Asset { get { return m_asset; } set { m_asset = value; } }
            public int Count { get { return m_count; } set { m_count = value; } }
            public int Capacity { get { return m_capacity; } set { m_capacity = value; } }
            public bool ExpandEnable { get { return m_expandEnable; } set { m_expandEnable = value; } }
            public int ExpandCount { get { return m_expandCount; } set { m_expandCount = value; } }
            public int ExpandThreshold { get { return m_expandThreshold; } set { m_expandThreshold = value; } }
            public bool TrimEnable { get { return m_trimEnable; } set { m_trimEnable = value; } }
            public int TrimCount { get { return m_trimCount; } set { m_trimCount = value; } }
            public int TrimThreshold { get { return m_trimThreshold; } set { m_trimThreshold = value; } }

            public PoolAssetDynamicDescription Build()
            {
                return new PoolAssetDynamicDescription(
                    m_loader,
                    m_asset,
                    m_count,
                    m_capacity,
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
}
