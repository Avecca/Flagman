using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInput : MonoBehaviour
{

    public enum Button
    {
        btnOne,
        btnTwo,
        btnThree,
        btnFour
    }

    [HideInInspector]
    public Button button;

    // btn events
    public delegate void ButtonPressed();
    public static event ButtonPressed btnOne;
    public static event ButtonPressed btnTwo;
    public static event ButtonPressed btnThree;
    public static event ButtonPressed btnFour;

    //säg åt compilatorn att viss kod körs på vissa enheter
    //koden kan bli enhets specifik

    //Används endast om kompilerat i edito‹rn UNITY_EDITOR eller UNITY_IOS

    //TODO Remove UNITY_EDITOR after
#if (UNITY_IOS || UNITY_ANDROID ) //|| UNITY_EDITOR

    private void Update()
    {
         foreach (Touch touch in Input.touches)
        {
            //om fler knappar se till at scriptet ligger på "över" knappen och inte individerna
            if (touch.phase == TouchPhase.Began)
            {
                //Visar skärmens pixel position
                // Debug.Log("Touch started: " + touch.position);
                //omvandla till spelets coord, genom att använda kameran, eftersom kameran ahr en snapshot bild av spelet utifrån

                Vector3 pos = Camera.main.ScreenToWorldPoint(touch.position);

                //Debug.Log("Touch world pos" + pos); //mitten blir då 0,0,-10

                //se om den omvandlade pos är över en Inputknapp med raycast
                RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);  //vector2.zero är rätt in

               // Debug.Log("Touch på knapp coord: " + hit);
                btnPressed(hit);

            }
          }
    }

#elif UNITY_EDITOR

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

            //Debug.Log("Mouse touch world pos");
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
            btnPressed(hit);

        }
    }

#elif UNITY_STANDALONE_OSX

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

            //Debug.Log("Mouse touch world pos");
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
            btnPressed(hit);

        }
    }


#endif

    private void btnPressed(RaycastHit2D hit)
    {
        //Debug.Log("Inne i  btnPressed");

        //TODO ändra till switch case

        if (btnOne != null && hit.collider != null && hit.collider.tag == "btnOne") //hit.collider.gameObject.name="LeftInput"" //taggar inputsen
        {
           //Debug.Log("BtnOne pressed");
            btnOne();
        }
        else if (btnTwo != null && hit.collider != null && hit.collider.tag == "btnTwo")
        {
            //Debug.Log("Btntwo pressed");
            btnTwo();
        }
        else if (btnThree != null && hit.collider != null && hit.collider.tag == "btnThree")
        {
            //Debug.Log("BtnThree pressed");
            btnThree();
        }
        else if (btnFour != null && hit.collider != null && hit.collider.tag == "btnFour")
        {
        //    Debug.Log("BtnFour pressed");
            btnFour();
        }
    }
}
