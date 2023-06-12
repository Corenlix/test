using System;
using System.Threading.Tasks;

namespace LoadOperation
{
    public class WaitOperation : ILoadingOperation
    {
        public string Description { get; }
        private readonly int _waitingTime;

        public WaitOperation(string description, int waitingTime)
        {
            Description = description;
            _waitingTime = waitingTime;
        }

        public async Task Load(Action<float> onProgress)
        {
            await Task.Delay(_waitingTime / 3);
            onProgress?.Invoke(0.33f);
            
            await Task.Delay(_waitingTime / 3);
            onProgress?.Invoke(0.66f);
            
            await Task.Delay(_waitingTime / 3);
            onProgress?.Invoke(1f);
        }
    }
}