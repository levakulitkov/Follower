using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    private bool _isGrouded;
    private Vector3 _normal;

    private void OnCollisionStay(Collision collisionInfo)
    {
        foreach (ContactPoint contact in collisionInfo.contacts)
        {
            if (contact.point.y < transform.position.y)
            {
                _isGrouded = true;
                _normal = contact.normal;
                break;
            }
        }
    }

    public bool CheckWithReset()
    {
        bool result = _isGrouded;
        _isGrouded = false;

        return result;
    }

    public Vector3 Project(Vector3 forward)
    {
        Vector3 forwardAlongGround = forward - Vector3.Dot(forward, _normal) * _normal;

        return forwardAlongGround;
    }
}