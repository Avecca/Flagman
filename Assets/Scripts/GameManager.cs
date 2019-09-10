using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    //Game manager connects the flaground with the guessinground the rounds and restarting after guessing


    //Under the same "item" Dino 
    FlagOrganizer flagOrganizer;
    GuessController guessController;

    //seperate entitys, connect through inspector
    public LivesController livesController;
    //Hide and show Input buttons
    public GameObject input;
    public TextMeshPro roundTxt;

    //TODO list of all the positions the flag has been in, make private
    public List<int> flagNumberList = new List<int>();

    //TODO SET private
    public bool gameOver = false;
    private bool doneGuessing = false;


    //TODO ADD SOUND
    //TODO Game over popup
    //TODO ANIMATIONS BETWEEN ROUNDS, wrong guess thingy
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

        livesController.CreateLives();
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

    public void StartNewRound()
    {
        flagNumberList.Clear();
        guessController.ResetNrGuesses();
    }

    public void SetInputVisiblity(bool visibile)
    {
        input.SetActive(visibile);
    }

    public void WrongGuessConsequences()
    {
        flagOrganizer.ResetMaxNrCFlagsToShowThisRoundTo();

        //Loose a life, check if game over
        if (!livesController.StillAlive())
        {
            GameOver();
        }
    }

    public void UpDateRoundNrDisplay(int round)
    {
        if (round > 0)
        {
            roundTxt.text = round.ToString();

        }   
    }

    private void GameOver()
    {
        Debug.Log("GAME OVER");
        gameOver = true;
        //GAME OVER

        //TODO Game Over popup
    }



    //public int GetROundNr()
    //{
    //    //For display,
    //    //as soon as a round starts this increases so to show the right nr
    //    //show one less
    //    return flagOrganizer.MaxNrFlagsToShowThisRound -1;
    //}


}
