using UnityEngine;
using UnityEngine.InputSystem;

public class MouseManager : Singleton<MouseManager>
{
    private bool isMouseLocked;
    private bool mouseInWindow;
    private bool awaitingMouseEntry;

    public void LockMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isMouseLocked = true;
    }

    public void UnlockMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isMouseLocked = false;
    }

    public void ToggleMouseLock()
    {
        if (isMouseLocked)
        {
            UnlockMouse();
        }
        else
        {
            LockMouse();
        }
    }

    public bool IsMouseLocked()
    {
        return isMouseLocked;
    }
}
