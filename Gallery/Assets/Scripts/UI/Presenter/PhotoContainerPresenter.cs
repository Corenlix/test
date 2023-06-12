using System.Collections.Generic;
using System.Threading.Tasks;
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
        [SerializeField] private int _startPhotosCount = 4;
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

        private async void Start()
        {
            _view.OnDown += OnDown;
            await LoadPhotos(_startPhotosCount);
        }

        private async Task LoadPhotos(int count)
        {
            _loadingDelayIsActive = true;
            
            var tasks = new Task<Texture2D>[count];
            for (var i = 0; i < count; i++)
                tasks[i] = _photoLoader.LoadNext();

            foreach (var texture in await Task.WhenAll(tasks))
            {
                AddPhoto(texture);
            }

            await Task.Delay(100);

            _loadingDelayIsActive = false;
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
            await LoadPhotos(_loadingPhotosCount);
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