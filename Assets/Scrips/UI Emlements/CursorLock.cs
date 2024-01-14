using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorLock : MonoBehaviour
{

    void Start()
    {
        LockCursor();
    }

    public void UnlockCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

        public void LockCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

}
