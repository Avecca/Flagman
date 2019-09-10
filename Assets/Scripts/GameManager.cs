using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    //Game manager connects the flaground with the guessinground the rounds and restarting after guessing

    FlagOrganizer flagOrganizer;
    GuessController guessController;
    //Hide and show Input buttons
    //defined through inspector
    public GameObject input;

    //TODO list of all the positions the flag has been in, make private
    public List<int> flagNumberList = new List<int>();

    public TextMeshPro roundTxt;

    private bool gameOver = false;
    private bool doneGuessing = false;


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

        //roundTxt.text = "1";

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

    //public int GetROundNr()
    //{
    //    //For display,
    //    //as soon as a round starts this increases so to show the right nr
    //    //show one less
    //    return flagOrganizer.MaxNrFlagsToShowThisRound -1;
    //}

    public void UpDateRoundNrDisplay(int round)
    {
        if (round > 0)
        {
            roundTxt.text = round.ToString();

        }   
    }

    public void StartNewRound()
    {
        flagNumberList.Clear();
        guessController.ResetNrGuesses();
    }


}
