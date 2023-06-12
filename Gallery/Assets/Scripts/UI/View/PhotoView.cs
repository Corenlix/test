using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.View
{
    public class PhotoView : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Image _image;
        public event Action<Texture2D> PreviewRequired;

        public void Init(Texture2D texture)
        {
            _image.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            PreviewRequired?.Invoke(_image.sprite.texture);
        }
    }
}