using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Gallery.PhotoLoader
{
    public interface IPhotoLoader
    {
        event Action<Texture2D[]> Loaded;
        Task<Texture2D[]> LoadNext(int count);
    }
}