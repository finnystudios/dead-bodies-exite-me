using Core;
using UnityEngine;

namespace Managers
{
    public class MouseManager : Singleton<MouseManager>
    {
        private bool _mouseInWindow;
        private bool _isMouseLocked;
        private bool _awaitingMouseEntry;

        public void LockMouse()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            _isMouseLocked = true;
        }

        // ReSharper disable once MemberCanBePrivate.Global
        public void UnlockMouse()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            _isMouseLocked = false;
        }

        public void ToggleMouseLock()
        {
            if (_isMouseLocked)
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
            return _isMouseLocked;
        }
    }
}