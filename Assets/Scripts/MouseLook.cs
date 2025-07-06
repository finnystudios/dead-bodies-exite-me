using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
	[SerializeField] private Transform cameraTransform;
	[SerializeField] private float mouseSensitivity = 0.1f;

	private float pitch = 0f;

    public void OnLook(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        Vector2 lookDelta = context.ReadValue<Vector2>() * mouseSensitivity;

        // Apply pitch (camera)
        pitch -= lookDelta.y;
        pitch = Mathf.Clamp(pitch, -90f, 90f);
        cameraTransform.localRotation = Quaternion.Euler(pitch, 0f, 0f); // The fuck is a quaternion

        // Apply yaw (player)
        transform.Rotate(Vector3.up, lookDelta.x);
        Debug.Log(gameObject.transform.rotation.y);
	}

	private void Start()
	{
        MouseManager.Instance.LockMouse();
    }
}
