using System;
using System.Threading.Tasks;

namespace LoadOperation
{
    public class WaitTaskOperation : ILoadingOperation
    {
        public string Description { get; }
        private readonly Task _operation;

        public WaitTaskOperation(string description, Task operation)
        {
            Description = description;
            _operation = operation;
        }
        
        public async Task Load(Action<float> onProgress)
        {
            await _operation;
        }
    }
}