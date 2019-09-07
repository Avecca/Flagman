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

    //list of all the positions the flag has been in, make private
    public List<int> flagNumberList = new List<int>();



    int maxNrFlagsToShowThisRound; //TODO Flagorganiser sätter detta, så 1 2 -3 osv
    int turn = 1;
    //int nrFlagsShown = 0;
   // int lastFlagPos = 0;

    float flagDelay = 2.0f;





    //BOOL för flagga nästa round

    bool nextRound = false;
    bool doneGuessing = false;

    bool GameOver = false;




    


    // Start is called before the first frame update
    void Start()
    {
       // Debug.Log("FlagOrganizer found");

        if (flagPrefab == null)
        {
            return;
        }

        //maybe fetch gamemanager (handle points?)
        maxNrFlagsToShowThisRound = 1;

        StartFlag();

        StartCoroutine(PickNextFlag());
        
    }

    IEnumerator PickNextFlag()
    {

        Debug.Log("Starting new round !!!");
        while (!GameOver)  //TODO !GameOver
        {




            // while (nextRound && maxNrFlagsToShowThisRound <= turn)
            // {
            //   turn++;
            //yield return new WaitUntil(() => doneGuessing == true);

            // if (nextRound)
            // {
            // yield return new WaitUntil(() => doneGuessing == true);


            // TODO ändra detta till doneguessing
            yield return new WaitUntil(() => nextRound == true);

               // yield return new WaitForSeconds(5.0f);
            Debug.Log(nextRound + " is the nextround");

                //TODO ändra detta till wautintil
                //yield return new WaitForSeconds(5.0f);
            StartFlag();
           // }
            //}

        }
        
    }

    // Update is called once per frame

    void Update()
    {
        

        //TODOIF Finished round and finished guessing restart the flag here
        //maxNrFlagsToShowThisRound++;

    }




    private void StartFlag()
    {

        UpdateNextRoundBool(false);
        //Debug.Log("StartFlag called");

        GameObject flag = Instantiate(flagPrefab);
        //flag.GetComponent<FlagController>().lastFlagPos = lastFlagPos;
        //nrFlagsShown++;

        //give the flagcontroller the flagorganizerts "id", so we can update FO from FC
        FlagController flagController = flag.GetComponentInChildren<FlagController>();
        flagController.flagOrganizer = this;

        //Tell the flagcontroller how many flags to show this round
        flag.GetComponent<FlagController>().maxNrFlagsToShow = maxNrFlagsToShowThisRound;

        maxNrFlagsToShowThisRound++;



    }

    public void UpdateFlagList(int nr)
    {

        flagNumberList.Add(nr);

        
    }

    public void EmptyFlagNumberList()
    {

        flagNumberList.Clear();

    }

    public void UpdateNextRoundBool(bool roundStatus)
    {

        Debug.Log("Updateboolean to :" + roundStatus);
        nextRound = roundStatus;
    }

    //TODO här eller i Flagcontroller
    //IEnumerator PickNextFlag()
    //{
    //    while (nrFlagsShown < maxNrFlagsToShow)
    //    {


    //        yield return new WaitForSeconds(flagDelay);
    //        StartFlag();

    //    }

    //    //TODO Gör så sista flaggan inte syns, ie döda

    //    if (nrFlagsShown >= maxNrFlagsToShow)
    //    {

    //        //STart guessing round, nedela game manager

    //        maxNrFlagsToShow++;

    //    }


    //}


}
