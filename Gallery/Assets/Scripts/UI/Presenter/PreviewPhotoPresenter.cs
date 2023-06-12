using UI.View;
using UnityEngine;
using Zenject;

namespace UI.Presenter
{
    public class PreviewPhotoPresenter : MonoBehaviour
    {
        [SerializeField] private PreviewPhotoView _view;
        private AppData _appData;

        [Inject]
        private void Inject(AppData appData)
        {
            _appData = appData;
        }

        private void Start()
        {
            _view.OnNext(_appData.PreviewTexture);
        }
    }
}