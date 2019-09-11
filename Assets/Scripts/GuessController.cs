using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuessController : MonoBehaviour
{
    //Handles the guessing round

    GameManager gameManager;

    //TODO Remove, does nothing, for inspector
    public List<int> guesses = new List<int>();
    private int nrGuessesDone = 0;

    float endRoundDelay = 2.0f;

    //private int guessNr = 0;

    // prenumerera på eventen från ButtonInput
    private void OnEnable()
    {
        ButtonInput.btnOne += OnOnePressed;
        ButtonInput.btnTwo += OnTwoPressed;
        ButtonInput.btnThree += OnThreePressed;
        ButtonInput.btnFour += OnFourPressed;
    }

    //avsluta prenumerationerna från ButtonInput
    private void OnDisable()
    {
        ButtonInput.btnOne -= OnOnePressed;
        ButtonInput.btnTwo -= OnTwoPressed;
        ButtonInput.btnThree -= OnThreePressed;
        ButtonInput.btnFour -= OnFourPressed;
    }

    // Start is called before the first frame update
    void Start()
    {
        //TODO If check here
        gameManager = GetComponent<GameManager>();
    }
    // Prenumererade events

    public void OnOnePressed()
    {
        Debug.Log("BtnOne pressed in guess");
        //The index start at 0 not 1
        CheckGuess(0); 
    }

    public void OnTwoPressed()
    {
        Debug.Log("Btntwo pressed in guess");
        CheckGuess(1);
    }

    public void OnThreePressed()
    {
        Debug.Log("BtnThree pressed in guess");
        CheckGuess(2);
    }

    public void OnFourPressed()
    {
        Debug.Log("BtnFour pressed in guess");
        CheckGuess(3);
    }

    public void ResetNrGuesses()
    {
        nrGuessesDone = 0;
    }

    private void CheckGuess(int guess)
    {

       // Debug.Log("Guessing Done, guess = " + guess + " listcount = " + gameManager.flagNumberList.Count);

        if (gameManager.flagNumberList.Count > nrGuessesDone)
        {
            if (gameManager.flagNumberList[nrGuessesDone] == guess)
            {
                GuessedRight(guess);
            }
            else
            {
                GuessedWrong();
            }
        }
        else
        {
            //Just in case something goes wrong
            Debug.Log("Inga fler att gissa på");

            EndGuessingRound();
        }
    }

    private void GuessedRight(int guess)
    {
        AddGuess(guess);
        nrGuessesDone++;

        Debug.Log("Gissade rätt!!");

        if (nrGuessesDone >= gameManager.flagNumberList.Count)
        {
            gameManager.SuccessfullRoundConsequences();
            StartCoroutine( EndGuessingRound() );
        }

        // DidRoundEnd();
    }
    private void GuessedWrong()
    {
        Debug.Log("Gissade fel!!");

        //If not game over loose a life
        //restart ROUND, next round has to have the same amount of flags
        gameManager.WrongGuessConsequences();  //TODO Rename LooseALife?

        StartCoroutine(EndGuessingRound());
    }

    IEnumerator EndGuessingRound()
    {
       // Debug.Log("ENDING ROUND");
        
        Debug.Log("END guessing round, HIDE buttons");
        // INSTA Ta bort knapparna
        gameManager.SetInputVisiblity(false);

        //reset guesses for next round
        RemoveAllGuesses();


        yield return new WaitForSeconds(endRoundDelay);

        if (!gameManager.GameOver) //GetGameOver()
        {
            gameManager.DoneGuessing = true;  //SetDoneGuessing(true)

        }
    }

    private void RemoveAllGuesses()
    {
        guesses.Clear();
    }

    private void AddGuess(int guess)
    {
        guesses.Add(guess);

        //foreach (int g in guesses)
        //{
        //   // Debug.Log("All the guesses: " + g);
        //}
    }

}
