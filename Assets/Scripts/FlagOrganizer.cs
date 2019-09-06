using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagOrganizer : MonoBehaviour
{

    // 1 round of showing the flag 5 times(Flagcontroller handles the 5 showings)

        //Game manager handles the points and restarting after guessing

    [SerializeField]
    GameObject flagPrefab;

    //list of all the positions the flag has been in
    private List<int> flagPositionsList = new List<int>();





    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("FlagOrganizer found");

        if (flagPrefab == null)
        {
            return;
        }

        //maybe fetch gamemanager (handle points?)

        StartFlag();
        
    }

    // Update is called once per frame
    void Update()
    {

        //TODOIF Finished round and finished guessing restart the flag here

    }

    private void StartFlag()
    {
        Debug.Log("StartFlag called");

        GameObject flag = Instantiate(flagPrefab);

    }


}
