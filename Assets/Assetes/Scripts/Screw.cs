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
    bool IsGettingScrewedIn = false;
    public Transform ScrewedOutPosition;
    public Transform ScrewedInPosition;
    public Rigidbody m_Rigidbody;
    public TutorialScreenChanger tutorial;
    Collider[] m_Colliders;
    public LayerMask layer;
    void Update()
    {
        m_Colliders = Physics.OverlapBox(transform.position, gameObject.GetComponent<BoxCollider>().size, transform.rotation, layer);
        if (IsScrewed == true && !IsScrewedOut){
            transform.position = Vector3.MoveTowards(transform.position,ScrewedOutPosition.position, V);

            bool temp = false;
            foreach (Collider c in m_Colliders)
            {
                if (c.GetComponent<Socket>() != null) {
                    temp = true;
                
            }
                if (temp)
                {
                    ScrewedOut();
                }
            }
        }
        if (IsScrewed == true && IsScrewedOut)
        {

            transform.position = Vector3.MoveTowards(transform.position, ScrewedInPosition.position, V);
            bool temp = false;
            foreach (Collider c in m_Colliders)
            {
                if (c.GetComponent<Socket>() != null)
                {
                    m_Rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation; 
                }


            }
            

        }
        if(gameObject.transform.position == ScrewedInPosition.position)
        {
            IsScrewedOut= false;
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
                m_Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            }
            IsScrewed = false;
        }
    }

    public void ScrewedOut() {
        IsScrewed= false;
        IsScrewedOut = true;
        IsGettingScrewedIn = true;
        m_Rigidbody.constraints = RigidbodyConstraints.None;
        tutorial.ScreenNumber =2;
    }
    public void ScrewedIn()
    {
        IsScrewed = false;
        
        IsGettingScrewedIn = false;
        
        
    }
}
