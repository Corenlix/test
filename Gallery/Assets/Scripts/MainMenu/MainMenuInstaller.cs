using Zenject;

namespace MainMenu
{
    public class MainMenuInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<Menu>().FromNew().AsSingle();
        }
    }
}