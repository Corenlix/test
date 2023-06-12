using System.Collections.Generic;
using LoadOperation;
using UI.LoadingScreen;
using UnityEngine;

namespace Gallery
{
    public class Gallery
    {
        private readonly LoadingScreen _loadingScreen;
        private readonly AppData _appData;
        private GalleryState _state = GalleryState.None;

        public Gallery(LoadingScreen loadingScreen, AppData appData)
        {
            _loadingScreen = loadingScreen;
            _appData = appData;
        }

        public void Preview(Texture2D texture2D)
        {
            if (_state == GalleryState.Loading)
                return;

            _state = GalleryState.Loading;
            _appData.PreviewTexture = texture2D;
            var operations = new Queue<ILoadingOperation>();
            operations.Enqueue(new UnloadSceneOperation(Constants.Scenes.Gallery));
            operations.Enqueue(new LoadSceneOperation(Constants.Scenes.Preview));
            _loadingScreen.Load(operations);
        }

        private enum GalleryState
        {
            None,
            Loading,
        }
    }
}