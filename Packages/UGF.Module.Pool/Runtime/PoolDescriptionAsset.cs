using UGF.Builder.Runtime;
using UGF.EditorTools.Runtime.Assets;
using UGF.EditorTools.Runtime.Ids;
using UnityEngine;

namespace UGF.Module.Pool.Runtime
{
    public abstract class PoolDescriptionAsset : BuilderAsset<IPoolDescription>
    {
        [AssetId(typeof(PoolLoaderAsset))]
        [SerializeField] private GlobalId m_loader;

        public GlobalId Loader { get { return m_loader; } set { m_loader = value; } }
    }
}
