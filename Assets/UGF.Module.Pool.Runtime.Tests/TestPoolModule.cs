using System.Threading.Tasks;
using NUnit.Framework;
using UGF.Application.Runtime;

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

            launcher.Destroy();
        }
    }
}
