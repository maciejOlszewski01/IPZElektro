using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TutorialClose : MonoBehaviour
{
    public InputActionProperty close;
    public TutorialScreenChanger changer;


    private void Awake()
    {
        close.action.performed += Toggle;
    }

    private void OnDestroy()
    {
        close.action.performed -= Toggle;
    }

    private void Toggle(InputAction.CallbackContext context)
    {
        changer.close();
    }

}
