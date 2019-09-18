using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameController : MonoBehaviour
{
    private string sceneName = "Main";
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("STARTSCREEN has laoded");
    }

#if (UNITY_IOS || UNITY_ANDROID)

    private void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                Vector3 pos = Camera.main.ScreenToWorldPoint(touch.position);
                RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);  //vector2.zero är rätt in

                if (hit.collider != null && hit.collider.gameObject.name == "StartGame")
                {
                    StartGame();
                }
                else if (hit.collider != null && hit.collider.gameObject.name == "ButtonQuit")
                {
                    ExitGame();
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

           if (hit.collider != null && hit.collider.gameObject.name == "StartGame")
           {
              StartGame();
            }
            else if (hit.collider != null && hit.collider.gameObject.name == "ButtonQuit")
            {
                ExitGame();
            }
        }
    }

#elif UNITY_STANDALONE_OSX

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
           RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero); 

           if (hit.collider != null && hit.collider.gameObject.name == "StartGame")
           {
              StartGame();
           }
           else if (hit.collider != null && hit.collider.gameObject.name == "ButtonQuit")
           {
               ExitGame();
           }
        }
    }

#endif

    public void StartGame()
    {
        //Call the "Main" scene
        SceneManager.LoadScene(sceneName);
    }

    //TODO implementera knapp
    private void ExitGame()
    {

        Debug.Log("Quitting Game!");
        Application.Quit();
    }
}
