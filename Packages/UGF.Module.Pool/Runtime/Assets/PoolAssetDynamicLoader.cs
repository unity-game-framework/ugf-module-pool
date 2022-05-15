using UGF.Pool.Runtime.Unity;
using UGF.RuntimeTools.Runtime.Contexts;
using UnityEngine;

namespace UGF.Module.Pool.Runtime.Assets
{
    public class PoolAssetDynamicLoader<TAsset, TDescription> : PoolAssetLoader<TAsset, PoolCollectionDynamicObject<TAsset>, TDescription>
        where TAsset : Object
        where TDescription : PoolAssetDynamicDescription
    {
        protected override PoolCollectionDynamicObject<TAsset> OnCreateCollection(TAsset asset, TDescription description, IContext context)
        {
            var collection = new PoolCollectionDynamicObject<TAsset>(asset, context, description.Capacity)
            {
                DefaultCount = description.Count,
                ExpandAuto = description.ExpandEnable,
                ExpandCount = description.ExpandCount,
                ExpandThreshold = description.ExpandThreshold,
                TrimAuto = description.TrimEnable,
                TrimCount = description.TrimCount,
                TrimThreshold = description.TrimThreshold
            };

            return collection;
        }

        protected override TAsset OnGetAsset(PoolCollectionDynamicObject<TAsset> collection, TDescription description, IContext context)
        {
            return collection.Source;
        }
    }
}
