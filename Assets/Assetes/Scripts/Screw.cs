using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Screw : MonoBehaviour
{
    private const float V = 0.003f;
    public BoxCollider tip;
    bool IsScrewed = false;
    bool IsScrewedOut = false;
    public Transform ScrewedOutPosition;
    public Transform ScrewedInPosition;
    public Rigidbody m_Rigidbody;
    public TutorialScreenChanger tutorial;
    void Update()
    {
        if(IsScrewed == true){
            transform.position = Vector3.MoveTowards(transform.position,ScrewedOutPosition.position, V);
            if(transform.position == ScrewedOutPosition.position)
            {
                ScrewedOut();
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        
        if (other.GetComponentInParent<Screwdriver>() != null)
        {
            IsScrewed = true;
            if (IsScrewedOut == false)
            {
                m_Rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
            }
        };
    }

    public void OnTriggerExit(Collider other)
    {

        if (other.GetComponentInParent<Screwdriver>() != null)
        {
            if (IsScrewedOut == false)
            {
                IsScrewed = false;
            m_Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            }
        }
    }

    public void ScrewedOut() {
        IsScrewedOut = true;
        m_Rigidbody.constraints = RigidbodyConstraints.None;
        tutorial.ScreenNumber =2;
    }
}
