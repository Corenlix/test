using UnityEngine;

public class Player : MonoBehaviour
{
    private static readonly int MoveSpeed = Animator.StringToHash("MoveSpeed");
    private static readonly int Grounded = Animator.StringToHash("Grounded");
    private static readonly int JumpTrigger = Animator.StringToHash("Jump");
    [SerializeField] private Animator _animator;
    [SerializeField] private CharacterController _character;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private float _groundSphereRadius = 0.15f;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpStrength;
    private bool _grounded;
    private float _yVelocity;
    private static readonly int AttackTrigger = Animator.StringToHash("Attack");

    public void Move(Vector2 direction, float deltaTime)
    {
        _character.Move(Vector3.up * (_yVelocity * deltaTime));
        _grounded = Physics.OverlapSphere(transform.position, _groundSphereRadius, _groundMask.value).Length > 0;
        _animator.SetBool(Grounded, _grounded);

        if (!_grounded)
            _yVelocity += Physics.gravity.y * deltaTime;
        else if (_yVelocity < 0) _yVelocity = 0;

        if (Mathf.Approximately(direction.x, 0) && Mathf.Approximately(direction.y, 0))
        {
            _animator.SetFloat(MoveSpeed, 0);
            return;
        }

        direction = Vector2.ClampMagnitude(direction, 1);
        _animator.SetFloat(MoveSpeed, direction.magnitude);
        var moveVelocity = new Vector3(direction.x, 0, direction.y) * _speed;
        _character.transform.rotation = Quaternion.LookRotation(moveVelocity);
        _character.Move(moveVelocity * deltaTime);
    }

    public void Jump()
    {
        if (!_grounded) return;
        _yVelocity = _jumpStrength;
        _animator.SetTrigger(JumpTrigger);
    }

    public void Attack()
    {
        _animator.SetTrigger(AttackTrigger);
    }
}