using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesController : MonoBehaviour
{
    //Life handler, creates and removes when gamemanager calls for it

    //TODO Make variables private and not show in inspector

    //List of our lives
    public List<GameObject> lives = new List<GameObject>();

    private int startLives = 3;
    private float lifeDistance = 1.0f;

    //instantiate from gamemanager
    public void CreateLives()
    {
        //find the sample life
        GameObject sample = transform.GetChild(0).gameObject; //getchild bcs the script is on lives not life

        lives.Add(sample);

        //if error
        if (sample == null)
        {
            return;
        }


        //create starting lives
        for (int i = 1; i < startLives; i++)
        {
            GameObject life = Instantiate(sample);
            lives.Add(life);

            //bring to life
            //place at the same spot as parent
            life.transform.parent = transform;
            //get the position
            Vector3 lifePosition = life.transform.position;
            //change the position, x times the life icon since they all start at the same pos
            lifePosition.x += lifeDistance * (i);
            //change the to new position
            life.transform.position = lifePosition;

        }
    }

    //If no lives = game over
    public bool StillAlive()
    {
        //No more lives left to loose and it's game over
        if (lives.Count < 1) //<= 1 if not using a last life
        {
            //not alive
            return false;
        }

        //find the life at the end of the list
        GameObject life = lives[lives.Count - 1];
        lives.RemoveAt(lives.Count - 1);

        //Destroy the last life in the list
        Destroy(life);

        //still alive
        return true;
    }
}
