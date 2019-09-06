using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuessController : MonoBehaviour
{

    //TODO EMpty after each round
    public List<int> guesses = new List<int>();

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

        //TODO blink around the first empty guess window
        //UpdatePosition();
    }

    // Update is called once per frame
    void Update()
    {

    }


    // Prenumererade events

    public void OnOnePressed()
    {

        Debug.Log("BtnOne pressed");

        /* if (currentPosition > 0)
         {
             currentPosition--;
             UpdatePosition();
         }*/

        AddGuess(1);
    }

    public void OnTwoPressed()
    {
        Debug.Log("Btntwo pressed");
        AddGuess(2);

        /* if (currentPosition < positions.Count - 1)
         {
             currentPosition++;
             UpdatePosition();
         }*/
    }


    public void OnThreePressed()
    {
        Debug.Log("BtnThree pressed");
        AddGuess(3);

    }


    public void OnFourPressed()
    {
        Debug.Log("BtnFour pressed");
        AddGuess(4);

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
