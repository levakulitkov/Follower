using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(GroundChecker))]
public class RigidBodyMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 200f;
    [SerializeField] private float _slopeLimit = 45f;

    private Rigidbody _rigidbody;
    private GroundChecker _groundChecker;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _groundChecker = GetComponent<GroundChecker>();
    }

    public void Move()
    {
        if (_groundChecker.CheckWithReset())
            MoveTo(transform.forward);
    }

    private void MoveTo(Vector3 direction)
    {
        Vector3 directionAlongGround =
            _groundChecker.Project(direction).normalized;

        if (_slopeLimit > Vector3.Angle(direction, directionAlongGround))
        {
            Vector3 offset = _speed * Time.fixedDeltaTime * directionAlongGround;
            _rigidbody.velocity = offset;
        }
    }
}