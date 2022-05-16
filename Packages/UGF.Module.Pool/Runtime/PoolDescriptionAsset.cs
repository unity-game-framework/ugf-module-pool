using UGF.Builder.Runtime;
using UGF.EditorTools.Runtime.IMGUI.Attributes;
using UnityEngine;

namespace UGF.Module.Pool.Runtime
{
    public abstract class PoolDescriptionAsset : BuilderAsset<IPoolDescription>
    {
        [AssetGuid(typeof(PoolLoaderAsset))]
        [SerializeField] private string m_loader;

        public string Loader { get { return m_loader; } set { m_loader = value; } }
    }
}
