using System.Collections.Generic;
using LoadOperation;
using UI.LoadingScreen;

namespace MainMenu
{
    public class Menu
    {
        private readonly LoadingScreen _loadingScreen;
        private MenuState _state = MenuState.None;

        public Menu(LoadingScreen loadingScreen)
        {
            _loadingScreen = loadingScreen;
        }

        public void LoadGallery()
        {
            if (_state == MenuState.Loading)
                return;
        
            _state = MenuState.Loading;
            var operations = new Queue<ILoadingOperation>();
            operations.Enqueue(new UnloadSceneOperation(Constants.Scenes.MainMenu));
            operations.Enqueue(new LoadSceneOperation(Constants.Scenes.Gallery));
            operations.Enqueue(new WaitOperation("Сидим...", 1500));
            operations.Enqueue(new WaitOperation("Ждем...", 1500));
            _loadingScreen.Load(operations);
        }

        enum MenuState
        {
            None,
            Loading,
        }
    }
}