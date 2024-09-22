using UnityEngine;

public class PlayerCameraTarget : MonoBehaviour
{
    private const float VerticalMinAngle = -90 + float.Epsilon;
    private const float VerticalMaxAngle = 90 - float.Epsilon;

    [SerializeField] private float _verticalTernSensitivity = 10f;
    [SerializeField] private Transform _player;

    private float _cameraAngle;

    private void Awake()
    {
        _cameraAngle = Vector3.SignedAngle(_player.forward, transform.forward, _player.right);
    }

    public void Rotate(float verticalTern)
    {
        float newAngle = _cameraAngle + verticalTern * _verticalTernSensitivity;
        newAngle = Mathf.Clamp(newAngle, VerticalMinAngle, VerticalMaxAngle);

        transform.RotateAround(_player.position, _player.right, newAngle - _cameraAngle);

        _cameraAngle = newAngle;
    }
}