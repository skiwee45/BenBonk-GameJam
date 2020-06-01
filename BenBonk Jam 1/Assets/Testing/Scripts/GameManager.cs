using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] levels = new GameObject[10];
    private bool levelDone = false;
    public PanelFader fader;

    // Update is called once per frame
    void Update()
    {
        
    }
    public void killEnemy() //when player kills an enemy this is called
    {
        
    }

    void loadNextLevel() //when next level must be loaded
    {
        //black screen in and out
        StartCoroutine(fadeINOUT());
        //pick random next
        //load next
        //disable current

    }
    IEnumerator fadeINOUT()
    {
        fader.FadeIn();
        //Wait for 2 seconds
        yield return new WaitForSeconds(2);
        fader.FadeOut();
    }
}
