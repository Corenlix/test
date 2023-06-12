using Zenject;

namespace Gallery.PhotoLoader
{
    public class PhotoLoaderInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IPhotoLoader>().To<IpkbPhotoLoader>().AsSingle();
        }
    }
}