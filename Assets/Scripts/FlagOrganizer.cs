using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagOrganizer : MonoBehaviour
{

    // 1 round of showing the flag 5 times(Flagcontroller handles the 5 showings)

    //Game manager connects the flaground with the guessinground the rounds and restarting after guessing

    [SerializeField]
    GameObject flagPrefab;

    GameManager gameManager;

    //TODO MAKE PRIVATE
   private int maxNrFlagsToShowThisRound; 

    // int turn = 1;
    //int nrFlagsShown = 0;
    // int lastFlagPos = 0;

    float flagDelay = 2.0f;


    //TODO samma som turn?  TA Bort när allt funkar?
    private int nrFlagsToStart = 1;

    //BOOL för flagga nästa round
    bool nextRound = false;


    public int MaxNrFlagsToShowThisRound
    {
        get
        {
            return maxNrFlagsToShowThisRound;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
       // Debug.Log("FlagOrganizer found");

        if (flagPrefab == null)
        {
            return;
        }

        gameManager = GetComponent<GameManager>();

        //maybe fetch gamemanager (handle points?)
        maxNrFlagsToShowThisRound = nrFlagsToStart;

        StartFlag();

        StartCoroutine(PickNextFlag());
        
    }

    IEnumerator PickNextFlag()
    {

        Debug.Log("Starting new round !!!");
        while (!gameManager.GetGameOver())  //TODO !GameOver
        {

            // while (nextRound && maxNrFlagsToShowThisRound <= turn)
            // {
            //   turn++;
            //yield return new WaitUntil(() => doneGuessing == true);

            // if (nextRound)
            // {
             yield return new WaitUntil(() => gameManager.GetDoneGuessing() == true);

            // TODO ändra detta till doneguessing
            //yield return new WaitUntil(() => nextRound == true);

               // yield return new WaitForSeconds(5.0f);
            Debug.Log(nextRound + " is the nextround");

                //TODO ändra detta till wautintil
                //yield return new WaitForSeconds(5.0f);
            StartFlag();
           // }
            //}

        }
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

        gameManager.UpDateRoundNrDisplay(maxNrFlagsToShowThisRound);

        maxNrFlagsToShowThisRound++;

    }

    public void UpdateFlagList(int nr)
    {
        gameManager.flagNumberList.Add(nr);
    }

    public void NewRoundStartClear()
    {
        gameManager.StartNewRound();
    }

    public void ResetMaxNrCFlagsToShowThisRoundTo()
    {
        if (maxNrFlagsToShowThisRound > 1)
        {
            maxNrFlagsToShowThisRound--;
        } 
    }


    public void UpdateNextRoundBool(bool roundStatus)
    {

        //At the start of each Flaground so more than 2 doesnt start
        Debug.Log("Updateboolean to :" + roundStatus);
        nextRound = roundStatus;

        Debug.Log("DONEGUESSING = FALSE");
        gameManager.SetDoneGuessing(false);
    }

    public void StartGuessingRound(bool status)
    {
        nextRound = status;
        //gameManager.StartGuessingRound();
        Debug.Log("Start guessing round, see buttons");
        gameManager.SetInputVisiblity(true);

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
