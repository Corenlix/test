using System.Collections.Generic;
using LoadOperation;
using UI.LoadingScreen;
using Zenject;

namespace MainMenu
{
    public class Menu
    {
        private readonly IFactory<LoadingScreen> _loadingScreenFactory;
        private MenuState _state = MenuState.None;

        public Menu(IFactory<LoadingScreen> loadingScreenFactory)
        {
            _loadingScreenFactory = loadingScreenFactory;
        }

        public void LoadGallery()
        {
            if (_state == MenuState.Loading)
                return;
        
            _state = MenuState.Loading;
            var operations = new Queue<ILoadingOperation>();
            operations.Enqueue(new WaitOperation("Сидим...", 1500));
            operations.Enqueue(new WaitOperation("Ждем...", 1500));
            operations.Enqueue(new LoadSceneOperation(Constants.Scenes.Gallery));
            _loadingScreenFactory.Create().Load(operations);
        }

        enum MenuState
        {
            None,
            Loading,
        }
    }
}