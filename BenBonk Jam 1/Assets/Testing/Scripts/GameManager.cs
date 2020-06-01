using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pathfinding;

public class GameManager : MonoBehaviour
{
    public GameObject[] levels = new GameObject[7];
    private int currentNumber;
    private GameObject currentLevel;
    public PanelFader fader;
    public Transform player;
    public Transform resetPlayerDestination;
    public AstarPath pathfinder;
    public int score;
    public Text records;
    private bool levelsDone;

    private void Start()
    {
        currentNumber = 0;
        currentLevel = Instantiate(levels[currentNumber]);
        pathfinder.Scan();
        score = 0;
        levelsDone = false;
    }
    public void loadNextLevel() //when next level must be loaded
    {
        //count evidences
        addScore();
        if (levelsDone == false)
        {
            //delete current from game
            Destroy(currentLevel);
            //black screen in and out
            StartCoroutine(fadeINOUT());
            //pick random next
            RandomGenerate();
            //reset player
            player.position = resetPlayerDestination.position;
        } else
        {
            bossLoad();
            Debug.Log("Boss Level");
        }
        
    }
    IEnumerator fadeINOUT()
    {
        fader.FadeIn();
        //Wait for 1 seconds
        yield return new WaitForSeconds(1);
        fader.FadeOut();
        //Wait for 1 seconds
        yield return new WaitForSeconds(1);
        //load next
        currentLevel = Instantiate(levels[currentNumber]);
        //re-scan map for enemies
        pathfinder.Scan();
    }

    public void RandomGenerate()
    {
        currentNumber = Random.Range(0, 7);
    }

    void addScore()
    {
        if (levelsDone == false)
        {
            score++;
            records.text = "" + score;
            if (score == 4)
            {
                levelsDone = true;
            }
        }
    }

    public bool getLevelsDone()
    {
        return levelsDone;
    }

    public void bossLoad()
    {
        Debug.Log("boss loaded");
    }
}
