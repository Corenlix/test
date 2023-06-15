using UnityEngine;
using Zenject;

namespace UI.LoadingScreen
{
    public class LoadingScreenInstaller : MonoInstaller
    {
        [SerializeField] private LoadingScreen _loadingScreen;
        
        public override void InstallBindings()
        {
            Container.BindIFactory<LoadingScreen>().FromMethod(container => container.InstantiatePrefabForComponent<LoadingScreen>(_loadingScreen));
        }
    }
}