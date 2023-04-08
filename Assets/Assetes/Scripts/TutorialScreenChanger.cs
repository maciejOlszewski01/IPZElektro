using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TutorialScreenChanger : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Canvas[] Informations;
    public int ScreenNumber = 0;
    private int last = -1;


    private void Start()
    {
        foreach (Canvas can in Informations)
        {
            can.gameObject.SetActive(false);
        }

    }

    private void Update()
    {
        if (last != ScreenNumber)
        {
            Informations[ScreenNumber].gameObject.SetActive(true);
            last = ScreenNumber;
        }
    }

    public void close() {
        Informations[ScreenNumber].gameObject.SetActive(false);
    }

}
