using System;
using UI.View;
using UnityEngine;

namespace UI.Presenter
{
    public class PhotoPresenter : MonoBehaviour
    {
        [SerializeField] private PhotoView _view;
        public event Action<Texture2D> PreviewRequired;

        private void Awake()
        {
            _view.PreviewRequired += OnPreviewRequired;
        }

        private void OnPreviewRequired(Texture2D texture)
        {
            PreviewRequired?.Invoke(texture);
        }

        public void OnNext(Texture2D texture)
        {
            _view.Init(texture);
        }

        private void OnDestroy()
        {
            _view.PreviewRequired -= OnPreviewRequired;
        }
    }
}