using System.Threading.Tasks;
using NUnit.Framework;
using UGF.Application.Runtime;
using UGF.EditorTools.Runtime.Ids;
using UGF.Pool.Runtime;
using UGF.Pool.Runtime.Unity;
using UnityEngine;

namespace UGF.Module.Pool.Runtime.Tests
{
    public class TestPoolModule
    {
        [Test]
        public async Task LoadAndUnload()
        {
            var launcher = new ApplicationLauncherResources("Launcher");

            await launcher.CreateAsync();

            var module = launcher.Application.GetModule<PoolModule>();

            IPoolCollection collection = await module.LoadAsync(new GlobalId("f49252ed0e77b454b9f998dd2061f950"));

            Assert.IsInstanceOf<PoolCollectionDynamicObject<Object>>(collection);
            Assert.AreEqual(4, collection.Count);

            launcher.Destroy();
        }
    }
}
