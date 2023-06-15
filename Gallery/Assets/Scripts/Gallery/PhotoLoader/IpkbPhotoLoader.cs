using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace Gallery.PhotoLoader
{
    public class IpkbPhotoLoader : IPhotoLoader
    {
        public event Action<Texture2D[]> Loaded;
        private const string Url = "https://data.ikppbb.com/test-task-unity-data/pics/";
        private int _currentIndex = 1;

        public async Task<Texture2D[]> LoadNext(int count)
        {
            var tasks = new Task<Texture2D>[count];
            for (var i = 0; i < count; i++)
                tasks[i] = LoadNext();
            
            var loaded = await Task.WhenAll(tasks);
            Loaded?.Invoke(loaded);
            return loaded;
        }

        private async Task<Texture2D> LoadNext()
        {
            using var www = UnityWebRequestTexture.GetTexture($"{Url}{_currentIndex++}.jpg");
            var asyncOp = www.SendWebRequest();
            while (!asyncOp.isDone)
                await Task.Delay(30);

            if (www.result != UnityWebRequest.Result.Success)
                return null;
            
            return DownloadHandlerTexture.GetContent(www);
        }
    }
}