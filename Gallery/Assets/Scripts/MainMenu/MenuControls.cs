using UnityEngine;
using Zenject;

namespace MainMenu
{
    public class MenuControls : MonoBehaviour
    {
        private Menu _menu;

        [Inject]
        private void Inject(Menu menu)
        {
            _menu = menu;
        }

        public void OnLoadGalleryRequested() => _menu.LoadGallery();
    }
}