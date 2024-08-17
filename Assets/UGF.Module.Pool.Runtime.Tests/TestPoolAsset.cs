using UGF.Tables.Runtime;
using UnityEngine;

namespace UGF.Module.Pool.Runtime.Tests
{
    [CreateAssetMenu(menuName = "Tests/TestPoolAsset")]
    public class TestPoolAsset : ScriptableObject
    {
        [TableEntryDropdown(typeof(PoolDescriptionTableAsset))]
        [SerializeField] private Hash128 m_entry;

        public Hash128 Entry { get { return m_entry; } set { m_entry = value; } }
    }
}
