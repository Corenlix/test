using Zenject;

namespace Preview
{
    public class PreviewInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<Preview>().FromNew().AsSingle();
        }
    }
}