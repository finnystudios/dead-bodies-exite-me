using Managers;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float mouseSensitivity = 0.1f;

    private float _pitch;

    private void Start()
    {
        MouseManager.Instance.LockMouse();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        if (!context.performed || !MouseManager.Instance.IsMouseLocked)
            return;

        var lookDelta = context.ReadValue<Vector2>() * mouseSensitivity;

        // Apply pitch (camera)
        _pitch -= lookDelta.y;
        _pitch = Mathf.Clamp(_pitch, -90f, 90f);
        cameraTransform.localRotation = Quaternion.Euler(_pitch, 0f, 0f); // The fuck is a quaternion

        // Apply yaw (player)
        transform.Rotate(Vector3.up, lookDelta.x);
        Debug.Log(gameObject.transform.rotation.y);
    }
}