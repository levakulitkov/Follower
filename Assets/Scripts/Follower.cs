using UnityEngine;

[RequireComponent(typeof(FollowerSpotter), typeof(RigidBodyMovement))]
public class Follower : MonoBehaviour
{
    private FollowerSpotter _spotter;
    private RigidBodyMovement _mover;

    private void Awake()
    {
        _spotter = GetComponent<FollowerSpotter>();
        _mover = GetComponent<RigidBodyMovement>();
    }

    private void FixedUpdate()
    {
        _spotter.LookAtTarget();

        if (_spotter.CheckDistance())
        {
            _mover.Move();
        }
    }
}