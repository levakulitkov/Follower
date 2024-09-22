using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _lerpRate = 10f;

    private void LateUpdate()
    {
        Vector3 newPosition =
            Vector3.Lerp(transform.position, _target.position, Time.deltaTime * _lerpRate);
        Quaternion newRotation =
            Quaternion.Lerp(transform.rotation, _target.rotation, Time.deltaTime * _lerpRate);

        transform.SetPositionAndRotation(newPosition, newRotation);
    }
}