using UnityEngine;

public class FollowerSpotter : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _permissibleDistanceToTarget = 2f;

    public void LookAtTarget()
    {
        Vector3 xzTargetPosition =
            new Vector3(_target.position.x, transform.position.y, _target.position.z);
        transform.LookAt(xzTargetPosition);
    }

    public bool CheckDistance()
    {
        float sqrDistance = (_target.position - transform.position).sqrMagnitude;

        return sqrDistance > _permissibleDistanceToTarget * _permissibleDistanceToTarget;
    }
}