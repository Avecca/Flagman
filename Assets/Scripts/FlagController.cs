using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagController : MonoBehaviour
{

    //1 flag 4 positions


    [SerializeField]
    private List<Transform> flagPosition = new List<Transform>();
    public int currentFlagPos = 0;
    int nrFlagsShown = 0;
    int maxNrFlagsToShow = 5;

    float flagDelay = 2.0f;

    //int maxNrFlagPositions = 4;
    System.Random rand;


    // Start is called before the first frame update
    void Start()
    {

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

        //TODO Gör så sista flaggan inte syns, ie döda

        if (nrFlagsShown >= maxNrFlagsToShow)
        {
            
            DestroyJumper();

        }

        
    }



    private void ShowNextFlag()
    {
        //generate new position for the flag
        pickRandomFlagPosition();

        //TODO if visat tillräckligt många flaggor redan

        ShowFlag();
    }

    private void pickRandomFlagPosition()
    {
        //randomize flagposition

        //TODO not the same flag twice in a row
        rand = new System.Random();

        int r = rand.Next(0, flagPosition.Count);
        Debug.Log("Random blev: " + r);

        //Cant move to the same position as last time unless it's the first time
        while (r == currentFlagPos && nrFlagsShown > 0)
        {

            Debug.Log("GENERATING NEW RANDOM BCS DUPLICATE");
            r = rand.Next(0, flagPosition.Count);
            Debug.Log("New Random blev: " + r);

        }

        

        currentFlagPos = r;

    }

    private void ShowFlag()
    {
        nrFlagsShown ++;

        Debug.Log("Nr flags show: " + nrFlagsShown);

        transform.position = flagPosition[currentFlagPos].position;

        //TODO Spara vilken flagga som visades i flaglistan
        

    }

    private void DestroyJumper()
    {

       // Debug.Log("Trying to remove flag");
        //TODO berätta för flagorganizer/GM att vi är klara

        //gameObject.SetActive(false);


        Destroy(gameObject);
        //TODO Destoy så det inte ligger massa flaggor kvar
        //GameObject flag = transform.parent.gameObject;
        //Debug.Log(flag);
        //Destroy(flag);
    }


}
