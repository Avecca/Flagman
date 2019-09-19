using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    //Game manager connects the flaground with the guessinground the rounds and restarting after guessing

    private string sceneName = "Start";
    //private string sceneName = "Main";

    //Under the same "item" Dino 
    FlagOrganizer flagOrganizer;
    GuessController guessController;

    //seperate entitys, connect through inspector
    public LivesController livesController;
    public SoundManager soundManager;
    //Hide and show Input buttons
    public GameObject input;
    public GameObject gameOverSign;
    public TextMeshPro roundTxt;
    
    //TODO list of all the positions the flag has been in, make private
    public List<int> flagNumberList = new List<int>();

    private bool gameOver = false;
    private bool doneGuessing = false;

    //TODO bryta ut guesses ur GC O GÖR GUESSORGANIZER
    //TODO säkerhet if sound !exist osv 

    public bool GameOver
    {
        get { return this.gameOver; }
        set { this.gameOver = value; }
    }

    public bool DoneGuessing
    {
        get { return this.doneGuessing; }
        set { this.doneGuessing = value; }
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
        gameOverSign.SetActive(false);
    }

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
            GameIsOver();
        }
        else
        {
            soundManager.PlayWrongGuessSound();
        }
    }

    internal void SuccessfullRoundConsequences()
    {
        soundManager.PlaySuccessfullRoundSound();
    }

    public void UpDateRoundNrDisplay(int round)
    {
        if (round > 0)
        {
            roundTxt.text = round.ToString();
        }   
    }

    private void GameIsOver()
    {
        //Debug.Log("GAME OVER");
        GameOver = true;
        //sound
        soundManager.PlayGameOverSound();
        //Game Over popup
        gameOverSign.SetActive(true);
    }

    public void RestartGame()
    {
        //recall the "Main" scene
        SceneManager.LoadScene(sceneName);
    }

}
