using UnityEngine;

public class OrientationInstaller : MonoBehaviour
{
    [SerializeField] private ScreenOrientation _orientation;

    private void Awake()
    {
        Screen.orientation = _orientation;
    }
}