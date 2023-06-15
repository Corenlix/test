using System.Collections.Generic;
using LoadOperation;
using UI.LoadingScreen;
using Zenject;

namespace Preview
{
    public class Preview
    {
        private readonly IFactory<LoadingScreen> _loadingScreenFactory;
        private PreviewState _state = PreviewState.None;

        public Preview(IFactory<LoadingScreen> loadingScreenFactory)
        {
            _loadingScreenFactory = loadingScreenFactory;
        }

        public void LoadGallery()
        {
            if (_state == PreviewState.Loading)
                return;

            _state = PreviewState.Loading;
            var operations = new Queue<ILoadingOperation>();
            operations.Enqueue(new LoadSceneOperation(Constants.Scenes.Gallery));
            _loadingScreenFactory.Create().Load(operations);
        }

        private enum PreviewState
        {
            None,
            Loading,
        }
    }
}