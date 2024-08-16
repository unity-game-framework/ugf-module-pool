using UGF.EditorTools.Runtime.Ids;
using UGF.Tables.Runtime;
using UnityEngine;

namespace UGF.Module.Pool.Runtime
{
    public abstract class PoolDescriptionTableEntry<TDescription> : ITableEntry where TDescription : IPoolDescription
    {
        [SerializeField] private Hash128 m_id;
        [SerializeField] private string m_name;

        public GlobalId Id { get { return m_id; } set { m_id = value; } }
        public string Name { get { return m_name; } set { m_name = value; } }

        public TDescription Build()
        {
            return OnBuild();
        }

        protected abstract TDescription OnBuild();
    }
}
