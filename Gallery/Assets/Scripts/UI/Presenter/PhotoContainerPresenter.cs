using System.Collections.Generic;
using Gallery.PhotoLoader;
using UI.View;
using UnityEngine;
using Zenject;

namespace UI.Presenter
{
    public class PhotoContainerPresenter : MonoBehaviour
    {
        [SerializeField] private PhotoContainerView _view;
        [SerializeField] private PhotoPresenter _photoPresenter;
        [SerializeField] private Transform _container;
        [SerializeField] private int _loadingPhotosCount = 2;
        private IPhotoLoader _photoLoader;
        private Gallery.Gallery _gallery;
        private readonly List<PhotoPresenter> _presenters = new();
        private bool _loadingDelayIsActive;

        [Inject]
        private void Inject(IPhotoLoader photoLoader, Gallery.Gallery gallery)
        {
            _photoLoader = photoLoader;
            _gallery = gallery;
        }

        private void Start()
        {
            _view.OnDown += OnDown;
            _photoLoader.Loaded += OnPhotosLoaded;
        }

        private void OnPhotosLoaded(Texture2D[] photos)
        {
            foreach (var texture in photos)
            {
                AddPhoto(texture);
            }
        }

        private void AddPhoto(Texture2D texture)
        {
            if (texture == null) return;
            var presenter = Instantiate(_photoPresenter, _container);
            presenter.OnNext(texture);
            _presenters.Add(presenter);
            presenter.PreviewRequired += OnPreviewRequired;
        }

        private async void OnDown()
        {
            if (_loadingDelayIsActive) return;
            _loadingDelayIsActive = true;
            await _photoLoader.LoadNext(_loadingPhotosCount);
            _loadingDelayIsActive = false;
        }

        private void OnPreviewRequired(Texture2D texture)
        {
            _gallery.Preview(texture);
        }

        private void OnDestroy()
        {
            _view.OnDown -= OnDown;
            foreach (var photoPresenter in _presenters)
            {
                photoPresenter.PreviewRequired -= OnPreviewRequired;
            }
        }
    }
}