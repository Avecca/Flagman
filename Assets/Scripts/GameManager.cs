using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    FlagOrganizer flagOrganizer;

    //göm och visa input knapparna

    // Start is called before the first frame update
    void Start()
    {

        Debug.Log("Game started");

        flagOrganizer = GetComponent<FlagOrganizer>();
        
    }


}
