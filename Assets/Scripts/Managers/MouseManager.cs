using Core;
using UnityEngine;

namespace Managers
{
    public class MouseManager : Singleton<MouseManager>
    {
        
        public bool IsMouseLocked {get; private set;}
        
        private bool _mouseInWindow;
        private bool _awaitingMouseEntry;

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
            {
                UnlockMouse();
            }
            else
            {
                LockMouse();
            }
        }

    }
}