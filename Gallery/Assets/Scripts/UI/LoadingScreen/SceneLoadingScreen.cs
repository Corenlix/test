using System.Collections;
using LoadOperation;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI.LoadingScreen
{
    public class SceneLoadingScreen : LoadingScreen
    {
        [SerializeField] private Canvas _root;
        [SerializeField] private TextMeshProUGUI _operationDescriptionText;
        [SerializeField] private TextMeshProUGUI _progressText;
        [SerializeField] private Image _progressFill;
        [SerializeField] private float _barFillSpeed = 1f;
        private float _targetFill;

        protected override void OnStartLoad()
        {
            var loadingScreenScene = SceneManager.CreateScene(Constants.Scenes.LoadingScreen);
            SceneManager.MoveGameObjectToScene(_root.gameObject, loadingScreenScene);
            SceneManager.MoveGameObjectToScene(new GameObject().AddComponent<Camera>().gameObject, loadingScreenScene);
            _root.enabled = true;
            StartCoroutine(UpdateProgressBar());
        }

        protected override void OnNextOperation(ILoadingOperation operation)
        {
            _operationDescriptionText.text = operation.Description;
            UpdateProgressText(0);
            _progressFill.fillAmount = 0;
            _targetFill = 0;
        }

        protected override void OnProgress(float progress)
        {
            _targetFill = progress;
            UpdateProgressText(progress);
        }

        private void UpdateProgressText(float progress)
        {
            _progressText.text = $"{(int)(progress * 100)}%";
        }

        protected override void OnFinishLoad()
        {
            SceneManager.UnloadSceneAsync(Constants.Scenes.LoadingScreen);
        }

        private IEnumerator UpdateProgressBar()
        {
            while (_root.enabled)
            {
                _progressFill.fillAmount = Mathf.Min(_progressFill.fillAmount + Time.deltaTime * _barFillSpeed, _targetFill);
                yield return null;
            }
        }
    }
}