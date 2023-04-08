using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bezpieczniki : MonoBehaviour
{

    //Sprawdzic czy mozna wywolywac onCol na wyznaczonym coliderze
    [SerializeField] TutorialScreenChanger Tutorial;
    // Start is called before the first frame update
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<TutorialNext>() != null)
        {

            Tutorial.ScreenNumber = 1;
        }
    }
}
