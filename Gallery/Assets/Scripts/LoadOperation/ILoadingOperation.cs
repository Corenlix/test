using System;
using System.Threading.Tasks;

namespace LoadOperation
{
    public interface ILoadingOperation
    {
        string Description { get; }
        Task Load(Action<float> onProgress);
    }
}