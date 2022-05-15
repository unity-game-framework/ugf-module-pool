using System.Threading.Tasks;
using UGF.Application.Runtime;
using UGF.Module.Assets.Runtime;
using UGF.Module.Pool.Runtime.Assets;
using UGF.RuntimeTools.Runtime.Contexts;
using UnityEngine;

namespace UGF.Module.Pool.Runtime.GameObjects
{
    public abstract class PoolGameObjectLoader<TComponent, TCollection, TDescription> : PoolAssetLoader<TComponent, TCollection, TDescription>
        where TComponent : Component
        where TCollection : class, IPoolAssetCollection<TComponent>
        where TDescription : PoolAssetDescription
    {
        protected override void OnUnload(TCollection collection, TDescription description, IContext context)
        {
            var assetsModule = context.Get<IApplication>().GetModule<IAssetModule>();

            assetsModule.Unload(description.AssetId, collection.Asset.gameObject);
        }

        protected override async Task OnUnloadAsync(TCollection collection, TDescription description, IContext context)
        {
            var assetsModule = context.Get<IApplication>().GetModule<IAssetModule>();

            await assetsModule.UnloadAsync(description.AssetId, collection.Asset.gameObject);
        }
    }
}
