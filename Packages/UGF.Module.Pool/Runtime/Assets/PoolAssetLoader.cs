using System.Threading.Tasks;
using UGF.Application.Runtime;
using UGF.Module.Assets.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;
using UnityEngine;

namespace UGF.Module.Pool.Runtime.Assets
{
    public abstract class PoolAssetLoader<TAsset, TCollection, TDescription> : PoolLoader<TCollection, TDescription>
        where TAsset : Object
        where TCollection : class, IPoolAssetCollection<TAsset>
        where TDescription : PoolAssetDescription
    {
        protected override TCollection OnLoad(TDescription description, IContext context)
        {
            var assetsModule = context.Get<IApplication>().GetModule<IAssetModule>();

            var asset = assetsModule.Load<TAsset>(description.AssetId);

            TCollection collection = OnCreateCollection(asset, description, context);

            collection.BuildAll(description.Count);

            return collection;
        }

        protected override async Task<TCollection> OnLoadAsync(TDescription description, IContext context)
        {
            var assetsModule = context.Get<IApplication>().GetModule<IAssetModule>();

            var asset = await assetsModule.LoadAsync<TAsset>(description.AssetId);

            TCollection collection = OnCreateCollection(asset, description, context);

            collection.BuildAll(description.Count);

            return collection;
        }

        protected override void OnUnload(TCollection collection, TDescription description, IContext context)
        {
            var assetsModule = context.Get<IApplication>().GetModule<IAssetModule>();

            collection.DestroyAll();

            assetsModule.Unload(description.AssetId, collection.Asset);
        }

        protected override async Task OnUnloadAsync(TCollection collection, TDescription description, IContext context)
        {
            var assetsModule = context.Get<IApplication>().GetModule<IAssetModule>();

            collection.DestroyAll();

            await assetsModule.UnloadAsync(description.AssetId, collection.Asset);
        }

        protected abstract TCollection OnCreateCollection(TAsset asset, TDescription description, IContext context);
    }
}
