using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    FlagOrganizer flagOrganizer;
    GuessController guessController;
    //list of all the positions the flag has been in, make private
    public List<int> flagNumberList = new List<int>();

    private bool gameOver = false;
    private bool doneGuessing = false;

    //göm och visa input knapparna

    // Start is called before the first frame update
    void Start()
    {

        Debug.Log("Game started");

        flagOrganizer = GetComponent<FlagOrganizer>();
        guessController = GetComponent<GuessController>();

        
    }

    public void StartNewRound()
    {
        flagNumberList.Clear();
        guessController.ResetNrGuesses();

        //TODO doneGuessing = false;

        //TODO göm knapparna
    }

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
        return gameOver;
    }

    public void SetDoneGuessing(bool value)
    {
        gameOver = value;
    }


}
