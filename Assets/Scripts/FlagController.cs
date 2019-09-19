using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagController : MonoBehaviour
{
    //1 flag X positions, Flagsequence for the round

    //TODO GÖMM saker från inspectorn

    [SerializeField]
    private List<Transform> flagPosition = new List<Transform>();
    public int currentFlagPos = 0;
    int nrFlagsShown = 0;
    public int maxNrFlagsToShow = 5; //TODO Flagorganiser sätter detta, så 1 2 -3 osv

    float flagDelay = 1.8f;
    System.Random rand;

    //Håll reda på din egen flagcontroller, så vi kan lägga till rand numnret i listan över sequencen
    public FlagOrganizer flagOrganizer;

    public Sprite flag1Sprite;
    public Sprite flag2Sprite;
    public Sprite flag3Sprite;
    public Sprite flag4Sprite;

    // Start is called before the first frame update
    void Start()
    {
       // flagOrganizer.UpdateNextRoundBool(false);

        //empty old flaglist
        flagOrganizer.NewRoundStartClear();

        pickRandomFlagPosition();
        //show the first flag
        ShowFlag();

        StartCoroutine(PickNextFlag());
    }

    IEnumerator PickNextFlag()
    {
        while (nrFlagsShown < maxNrFlagsToShow)
        {
            yield return new WaitForSeconds(flagDelay);
            ShowNextFlag();
        }

        if (nrFlagsShown >= maxNrFlagsToShow)
        {
            yield return new WaitForSeconds(flagDelay);
            DestroyFlag();

           // Debug.Log("LAST FLAG SHOWN, ENDING FLAG ROUND");
            //guessing round, show btns and so on
            flagOrganizer.EnableGuessing(true);          
        }    
    }

    private void ShowNextFlag()
    {
        //generate new position for the flag
        pickRandomFlagPosition();

        ShowFlag();
    }

    //randomize flagposition
    private void pickRandomFlagPosition()
    {
        rand = new System.Random();

        int r = rand.Next(0, flagPosition.Count);
        //Debug.Log("Random blev: " + r);

        //Cant move to the same position as last time unless it's the first time
        while (r == currentFlagPos && nrFlagsShown > 0)
        {
           // Debug.Log("GENERATING NEW RANDOM BCS DUPLICATE");
            r = rand.Next(0, flagPosition.Count);
            //Debug.Log("New Random blev: " + r);
        }
        currentFlagPos = r;
    }

    private void ShowFlag()
    {
        nrFlagsShown ++;
        //Debug.Log("Nr flags show: " + nrFlagsShown);

        SpriteRenderer spriteRenderer = GetComponent <SpriteRenderer>();
        // spriteRenderer.color = ColorPicker();
        spriteRenderer.sprite = SpritePicker();  //(Sprite)Resources.Load("Sprites/YellowBtn1");

        transform.position = flagPosition[currentFlagPos].position;

        //Save what flag gets shown in FO
        flagOrganizer.UpdateFlagList(currentFlagPos);
    }

    private Sprite SpritePicker()
    {
        switch (currentFlagPos)
        {
            case 0:
                return flag1Sprite;
            case 1:
                return flag2Sprite;
            case 2:
                return flag3Sprite;
            case 3:
                return flag4Sprite;
            default:
                return flag1Sprite;
        }
    }

    private void DestroyFlag()
    {
       // Debug.Log("Trying to remove flag");

        //gameObject.SetActive(false);
        //Destroy the flag object
        Destroy(gameObject);
        //GameObject flag = transform.parent.gameObject;
        //Debug.Log(flag);
        //Destroy(flag);
    }

}
