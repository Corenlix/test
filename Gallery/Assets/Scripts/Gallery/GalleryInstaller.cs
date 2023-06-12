using Zenject;

namespace Gallery
{
    public class GalleryInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<Gallery>().FromNew().AsSingle();
        }
    }
}