using System;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace LoadOperation
{
    public class LoadSceneOperation : ILoadingOperation
    {
        public string Description => "Грузим...";
        private readonly string _sceneName;

        public LoadSceneOperation(string sceneName)
        {
            _sceneName = sceneName;
        }
        
        public async Task Load(Action<float> onProgress)
        {
            var loadOperation = SceneManager.LoadSceneAsync(_sceneName, LoadSceneMode.Additive);
            while (!loadOperation.isDone)
            {
                onProgress(loadOperation.progress / 0.9f);
                await Task.Delay(1);
            }
        }
    }
}