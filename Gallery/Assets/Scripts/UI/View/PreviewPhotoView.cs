using UnityEngine;
using UnityEngine.UI;

namespace UI.View
{
    public class PreviewPhotoView : MonoBehaviour
    {
        [SerializeField] private Image _image;
        
        public void OnNext(Texture2D texture2D)
        {
            _image.sprite = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), Vector2.zero);
        }
    }
}