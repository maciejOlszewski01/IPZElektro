using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Socket : MonoBehaviour
{
    [SerializeField] GameObject ScrewPlacement;
    public Collider[] colliders;
    public bool screwed;
    public LayerMask layer;

    private void Start()
    {
        colliders = Physics.OverlapBox(ScrewPlacement.GetComponent<Transform>().position, ScrewPlacement.GetComponent<BoxCollider>().size, ScrewPlacement.GetComponent<Transform>().rotation, layer);

        foreach (Collider col in colliders)
        {
            if (col.GetComponent<Screw>() != null)
            {
                screwed= true;
            }
        }
    }
    void Update() {
       colliders = Physics.OverlapBox(ScrewPlacement.GetComponent<Transform>().position, ScrewPlacement.GetComponent<BoxCollider>().size, ScrewPlacement.GetComponent<Transform>().rotation, layer);

        foreach(Collider col in colliders)
        {
            
            if(col.GetComponent<Screw>() != null)
            {
                screwed = true;
                break;
            }
            screwed= false;
        }

        if (screwed)
        {
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition| RigidbodyConstraints.FreezeRotation;
        }
        else
        {
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
    }

   
}
