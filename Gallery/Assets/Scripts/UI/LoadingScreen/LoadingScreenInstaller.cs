using UnityEngine;
using Zenject;

namespace UI.LoadingScreen
{
    public class LoadingScreenInstaller : MonoInstaller
    {
        [SerializeField] private LoadingScreen _loadingScreen;
        
        public override void InstallBindings()
        {
            Container.Bind<LoadingScreen>().FromInstance(_loadingScreen).AsSingle();
        }
    }
}