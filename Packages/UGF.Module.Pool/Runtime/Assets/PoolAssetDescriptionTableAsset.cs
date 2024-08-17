using System;
using UGF.EditorTools.Runtime.Assets;
using UGF.EditorTools.Runtime.Ids;
using UnityEngine;
using Object = UnityEngine.Object;

namespace UGF.Module.Pool.Runtime.Assets
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Pool/Pool Asset Description Table", order = 2000)]
    public class PoolAssetDescriptionTableAsset : PoolDescriptionTableAsset<PoolAssetDescriptionTableAsset.Entry, PoolAssetDescription>
    {
        [Serializable]
        public struct Entry : IPoolDescriptionTableEntry<PoolAssetDescription>
        {
            [SerializeField] private Hash128 m_id;
            [SerializeField] private string m_name;
            [AssetId(typeof(PoolLoaderAsset))]
            [SerializeField] private Hash128 m_loader;
            [AssetId(typeof(Object))]
            [SerializeField] private Hash128 m_asset;
            [SerializeField] private int m_count;
            [SerializeField] private int m_capacity;

            public GlobalId Id { get { return m_id; } set { m_id = value; } }
            public string Name { get { return m_name; } set { m_name = value; } }
            public GlobalId Asset { get { return m_asset; } set { m_asset = value; } }
            public int Count { get { return m_count; } set { m_count = value; } }
            public int Capacity { get { return m_capacity; } set { m_capacity = value; } }

            public PoolAssetDescription Build()
            {
                return new PoolAssetDescription(
                    m_loader,
                    m_asset,
                    m_count,
                    m_capacity
                );
            }
        }
    }
}
