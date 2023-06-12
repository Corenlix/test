using System.Collections.Generic;
using LoadOperation;
using UI.LoadingScreen;

namespace Preview
{
    public class Preview
    {
        private readonly LoadingScreen _loadingScreen;
        private PreviewState _state = PreviewState.None;

        public Preview(LoadingScreen loadingScreen)
        {
            _loadingScreen = loadingScreen;
        }

        public void LoadGallery()
        {
            if (_state == PreviewState.Loading)
                return;

            _state = PreviewState.Loading;
            var operations = new Queue<ILoadingOperation>();
            operations.Enqueue(new UnloadSceneOperation(Constants.Scenes.Preview));
            operations.Enqueue(new LoadSceneOperation(Constants.Scenes.Gallery));
            operations.Enqueue(new WaitOperation("Грузим картинки...", 3000));
            _loadingScreen.Load(operations);
        }

        private enum PreviewState
        {
            None,
            Loading,
        }
    }
}