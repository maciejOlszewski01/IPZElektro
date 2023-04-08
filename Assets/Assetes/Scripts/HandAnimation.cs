using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandAnimation : MonoBehaviour
{
    [SerializeField] private InputActionProperty grabWithFingertipsAction;
    [SerializeField] private InputActionProperty grab;
    [SerializeField] private Animator handAnimator;
    // Update is called once per frame
    void Update()
    {
        float pressForceValueFingertips = grabWithFingertipsAction.action.ReadValue<float>();
        float pressForceValueGrab = grab.action.ReadValue<float>();
        handAnimator.SetFloat("Trigger", pressForceValueFingertips);
        handAnimator.SetFloat("Grip", pressForceValueGrab);
    }
}
