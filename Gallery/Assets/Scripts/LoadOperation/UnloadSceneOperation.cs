using System;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace LoadOperation
{
    public class UnloadSceneOperation : ILoadingOperation
    {
        public string Description => "Грузим...";
        private readonly string _sceneName;

        public UnloadSceneOperation(string sceneName)
        {
            _sceneName = sceneName;
        }

        public async Task Load(Action<float> onProgress)
        {
            var unloadOperation = SceneManager.UnloadSceneAsync(_sceneName);
            while (!unloadOperation.isDone)
            {
                onProgress(unloadOperation.progress / 0.9f);
                await Task.Delay(1);
            }
        }
    }
}