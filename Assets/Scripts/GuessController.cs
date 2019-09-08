using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuessController : MonoBehaviour
{
    GameManager gameManager;


    //TODO EMpty after each round
    public List<int> guesses = new List<int>();
    private int nrGuessesDone = 0;

    float endRoundDelay = 5.0f;


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
        gameManager = GetComponent<GameManager>();

        //UpdatePosition();
    }

    // Update is called once per frame
    void Update()
    {

    }


    // Prenumererade events

    public void OnOnePressed()
    {

        Debug.Log("BtnOne pressed in guess");

        /* if (currentPosition > 0)
         {
             currentPosition--;
             UpdatePosition();
         }*/


        //The index start at 0 not 1
        CheckGuess(0);
         
    }

    public void OnTwoPressed()
    {
        Debug.Log("Btntwo pressed in guess");

        /* if (currentPosition < positions.Count - 1)
         {
             currentPosition++;
             UpdatePosition();
         }*/
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

        Debug.Log("Guessing Done, guess = " + guess + " listcount = " + gameManager.flagNumberList.Count);

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

            EndGuessing();
        }



    }



    private void GuessedRight(int guess)
    {
        AddGuess(guess);
        nrGuessesDone++;

        Debug.Log("Gissade rätt!!");

        if (nrGuessesDone >= gameManager.flagNumberList.Count)
        {
            StartCoroutine( EndGuessing());
        }



        // DidRoundEnd();
    }
    private void GuessedWrong()
    {
        Debug.Log("Gissade fel!!");

        //TODO FÖRLORA LIVE OCH SE OM GAME OVER FÖRST SEN
        //TODO FLAGORGANIZER nrFlagsToStart = 1; SÅ börjar gissa om från 1


        
        // EndGuessing();
        //TODO Gissningen blev fel, avsluta/mindre liv
        //gameManager.SetDoneGuessing(true);
    }

    IEnumerator EndGuessing()
    {

        Debug.Log("ENDING ROUND");
        //TODO INSTA Ta bort knapparna

        //reset guesses for next round
        RemoveAllGuesses();


        yield return new WaitForSeconds(endRoundDelay);

        if (!gameManager.GetGameOver())
        {


            gameManager.SetDoneGuessing(true);


        }

    }

    private void RemoveAllGuesses()
    {
        guesses.Clear();
    }

    private void AddGuess(int guess)
    {

        guesses.Add(guess);

        foreach (int g in guesses)
        {
            Debug.Log("All the guesses: " + g);
        }
    }

    private void UpdatePosition()
    {

        //TODOcurrentpositon + 1 för att highlighta nästa tomma siffra
       // transform.position = positions[currentPosition].position;
    }
}
