using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class GameManager : MonoBehaviour
{
    public GameObject[] levels = new GameObject[10];
    private int currentNumber;
    private GameObject currentLevel;
    public PanelFader fader;
    public Transform player;
    public Transform resetPlayerDestination;
    public AstarPath pathfinder;

    private void Start()
    {
        currentNumber = 0;
        currentLevel = Instantiate(levels[currentNumber]);
        pathfinder.Scan();
    }
    public void loadNextLevel() //when next level must be loaded
    {
        //delete current from game
        Destroy(currentLevel);
        //black screen in and out
        StartCoroutine(fadeINOUT());
        //pick random next
        RandomGenerate();
        //load next
        currentLevel = Instantiate(levels[currentNumber]);
        //reset player
        player.position = resetPlayerDestination.position;
        Debug.Log("Next Level Loaded");
        //re-scan map for enemies
        pathfinder.Scan();
    }
    IEnumerator fadeINOUT()
    {
        fader.FadeIn();
        //Wait for 2 seconds
        yield return new WaitForSeconds(2);
        fader.FadeOut();
    }

    public void RandomGenerate()
    {
        currentNumber = Random.Range(0, 10);
    }
}
