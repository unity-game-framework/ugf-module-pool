using System.Collections.Generic;
using UGF.EditorTools.Runtime.Ids;
using UGF.Tables.Runtime;
using UnityEngine;

namespace UGF.Module.Pool.Runtime
{
    public abstract class PoolDescriptionTableAsset<TTableEntry, TDescription> : PoolDescriptionTableAsset
        where TTableEntry : PoolDescriptionTableEntry<TDescription>
        where TDescription : class, IPoolDescription
    {
        [SerializeField] private Table<TTableEntry> m_table = new Table<TTableEntry>();

        public Table<TTableEntry> Table { get { return m_table; } }

        protected override ITable OnGet()
        {
            return m_table;
        }

        protected override void OnSet(ITable table)
        {
            m_table = (Table<TTableEntry>)table;
        }

        protected override void OnGetDescriptions(IDictionary<GlobalId, IPoolDescription> descriptions)
        {
            for (int i = 0; i < m_table.Entries.Count; i++)
            {
                TTableEntry entry = m_table.Entries[i];

                TDescription description = entry.Build();

                descriptions.Add(entry.Id, description);
            }
        }
    }
}
