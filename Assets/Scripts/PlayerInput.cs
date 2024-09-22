using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class PlayerInput : MonoBehaviour
{
    [SerializeField] private PlayerCameraTarget _cameraTarget;
    [SerializeField] private PlayerMover _mover;

    private void Update()
    {
        _cameraTarget.Rotate(-Input.GetAxis("Mouse Y"));

        _mover.Rotate(Input.GetAxis("Mouse X"));

        _mover.Move(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"),
            Input.GetKeyDown(KeyCode.Space));
    }
}