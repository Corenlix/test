using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Joystick _joystick;

    private void Update()
    {
        _player.Move(_joystick.Direction, Time.deltaTime);
    }
}