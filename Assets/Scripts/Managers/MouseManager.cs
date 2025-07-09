using Core;
using UnityEngine;

namespace Managers
{
    public class MouseManager : Singleton<MouseManager>
    {
        private bool _awaitingMouseEntry;

        private bool _mouseInWindow;

        public bool IsMouseLocked { get; private set; }

        public void LockMouse()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            IsMouseLocked = true;
        }

        // ReSharper disable once MemberCanBePrivate.Global
        public void UnlockMouse()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            IsMouseLocked = false;
        }

        public void ToggleMouseLock()
        {
            if (IsMouseLocked)
                UnlockMouse();
            else
                LockMouse();
        }
    }
}