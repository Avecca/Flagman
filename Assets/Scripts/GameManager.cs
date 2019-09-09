using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    FlagOrganizer flagOrganizer;
    GuessController guessController;
    //TODO list of all the positions the flag has been in, make private
    public List<int> flagNumberList = new List<int>();

    private bool gameOver = false;
    private bool doneGuessing = false;

    //Hide and show Input buttons
    //defined through inspector
    public GameObject input;


    //TODO PRINT WHICH ROUND NUMBER
    //TODO ADD SOUND
    //TODO LIVES
    //TODO ANIMATIONS BETWEEN ROUNDS
    //TODO C# GetterSetters fix

    //TODO bryta ut guesses ur GC O GÖR GUESSORGANIZER

    public bool GetGameOver()
    {
        return gameOver;
    }

    public void SetGameOver(bool value)
    {
        gameOver = value;
    }

    public bool GetDoneGuessing()
    {
        return doneGuessing;
    }

    public void SetDoneGuessing(bool value)
    {

        doneGuessing = value;
    }



    // Start is called before the first frame update
    void Start()
    {

        Debug.Log("Game started");

        flagOrganizer = GetComponent<FlagOrganizer>();
        guessController = GetComponent<GuessController>();

        //Debug.Log("HIDE BTNS");
        input.SetActive(false);


    }

    //internal void StartGuessingRound()
    //{

    //    Debug.Log("Start guessing round, see buttons");
    //    input.SetActive(true);
    //}

    public void SetInputVisiblity(bool visibile)
    {
        input.SetActive(visibile);
    }

    public void BacktrackFlagRound()
    {
        flagOrganizer.ResetMaxNrCFlagsToShowThisRoundTo();
    }

    public void StartNewRound()
    {
        flagNumberList.Clear();
        guessController.ResetNrGuesses();
    }


}
