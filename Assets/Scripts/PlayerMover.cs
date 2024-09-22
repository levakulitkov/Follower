using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private float _rotationSpeed = 5f;
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _strafeSpeed = 3f;
    [SerializeField] private float _jumpSpeed = 5f;

    private Vector3 _verticalVelocity;

    public void Move(float verticalAxisInput, float horizontalAxisInput, bool jumped)
    {
        Vector3 horizontalVelocity = CalculateHorizontalVelocity(
            verticalAxisInput, horizontalAxisInput);
        Vector3 verticalVelocity = CalculateVerticalVelocity(jumped);

        _characterController.Move((horizontalVelocity + verticalVelocity) * Time.deltaTime);
    }

    public void Rotate(float horizontalTern)
    {
        _characterController.transform.Rotate(horizontalTern * _rotationSpeed * Vector3.up);
    }

    private Vector3 CalculateVerticalVelocity(bool jumped)
    {
        if (_characterController.isGrounded)
        {
            if (jumped)
            {
                _verticalVelocity = _jumpSpeed * Vector3.up;
            }
        }
        else
        {
            _verticalVelocity += Physics.gravity * Time.deltaTime;
        }

        return _verticalVelocity;
    }

    private Vector3 CalculateHorizontalVelocity(float verticalAxisInput, float horizontalAxisInput)
    {
        Vector3 horizontalVelocity;

        if (_characterController.isGrounded)
        {
            Vector3 forwardVelocity = verticalAxisInput * _speed * transform.forward;
            Vector3 strafeVelocity = horizontalAxisInput * _strafeSpeed * transform.right;

            horizontalVelocity = forwardVelocity + strafeVelocity;
        }
        else
        {
            horizontalVelocity = _characterController.velocity;
            horizontalVelocity.y = 0;
        }

        return horizontalVelocity;
    }
}