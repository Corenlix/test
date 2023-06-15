using System.Collections.Generic;
using Gallery.PhotoLoader;
using LoadOperation;
using UI.LoadingScreen;
using UnityEngine;
using Zenject;

namespace Gallery
{
    public class Gallery : IInitializable
    {
        private readonly IFactory<LoadingScreen> _loadingScreenFactory;
        private readonly IPhotoLoader _photoLoader;
        private readonly AppData _appData;
        private GalleryState _state = GalleryState.None;

        public Gallery(IFactory<LoadingScreen> loadingScreenFactory, IPhotoLoader photoLoader, AppData appData)
        {
            _loadingScreenFactory = loadingScreenFactory;
            _photoLoader = photoLoader;
            _appData = appData;
        }

        public void Preview(Texture2D texture2D)
        {
            if (_state == GalleryState.Loading)
                return;

            _state = GalleryState.Loading;
            _appData.PreviewTexture = texture2D;
            var operations = new Queue<ILoadingOperation>();
            operations.Enqueue(new LoadSceneOperation(Constants.Scenes.Preview));
            _loadingScreenFactory.Create().Load(operations);
        }

        public void Initialize()
        {
            var operations = new Queue<ILoadingOperation>();
            operations.Enqueue(new WaitTaskOperation("Грузим картинки...", _photoLoader.LoadNext(12)));
            _loadingScreenFactory.Create().Load(operations);
        }

        private enum GalleryState
        {
            None,
            Loading,
        }
    }
}