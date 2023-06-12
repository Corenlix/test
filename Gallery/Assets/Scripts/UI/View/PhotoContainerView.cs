using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.View
{
    public class PhotoContainerView : MonoBehaviour
    {
        [SerializeField] private ScrollRect _scroll;
        public event Action OnDown;

        private void Awake()
        {
            _scroll.onValueChanged.AddListener(OnScroll);
        }

        private void OnScroll(Vector2 scrollPosition)
        {
            if (scrollPosition.y <= 0f)
                OnDown?.Invoke();
        }
    }
}