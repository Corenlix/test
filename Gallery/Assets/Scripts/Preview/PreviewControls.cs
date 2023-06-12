using UnityEngine;
using Zenject;

namespace Preview
{
    public class PreviewControls : MonoBehaviour
    {
        private Preview _preview;
        
        [Inject]
        private void Inject(Preview preview)
        {
            _preview = preview;
        }
        
        public void OnLoadGalleryRequired()
        {
            _preview.LoadGallery();
        }
    }
}