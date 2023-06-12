using System.Threading.Tasks;
using UnityEngine;

namespace Gallery.PhotoLoader
{
    public interface IPhotoLoader
    {
        Task<Texture2D> LoadNext();
    }
}