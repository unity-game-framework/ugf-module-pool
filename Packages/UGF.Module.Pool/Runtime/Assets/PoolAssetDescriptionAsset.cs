using UGF.EditorTools.Runtime.IMGUI.Attributes;
using UnityEngine;

namespace UGF.Module.Pool.Runtime.Assets
{
    public abstract class PoolAssetDescriptionAsset : PoolDescriptionAsset
    {
        [AssetGuid(typeof(Object))]
        [SerializeField] private string m_asset;
        [SerializeField] private int m_count = 4;
        [SerializeField] private int m_capacity = 4;

        public string Asset { get { return m_asset; } set { m_asset = value; } }
        public int Count { get { return m_count; } set { m_count = value; } }
        public int Capacity { get { return m_capacity; } set { m_capacity = value; } }
    }
}
