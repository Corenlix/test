using UnityEngine;
using Zenject;

namespace Preview
{
    public class PreviewInput : MonoBehaviour
    {
        private Preview _preview;
        
        [Inject]
        private void Inject(Preview preview)
        {
            _preview = preview;
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _preview.LoadGallery();
            }
        }
    }
}