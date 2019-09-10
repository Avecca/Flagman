using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverSignController : MonoBehaviour
{

    public GameManager gameManager;

    //Dont forget to connect through the Inspector and through a boxcollider


#if (UNITY_IOS || UNITY_ANDROID)

    private void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                Vector3 pos = Camera.main.ScreenToWorldPoint(touch.position);
                RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);  //vector2.zero är rätt in

                if (hit.collider != null && hit.collider.gameObject.name == "GameOver")
                {
                    RestartGame();
                }
            }

        }
    }


#elif UNITY_EDITOR

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
           RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero); 

           if (hit.collider != null && hit.collider.gameObject.name == "GameOver")
           {
              RestartGame();
           }
        }
    }

#endif


    private void RestartGame()
    {
        //Debug.Log("Restart Game");
        gameManager.RestartGame();
    }
}
