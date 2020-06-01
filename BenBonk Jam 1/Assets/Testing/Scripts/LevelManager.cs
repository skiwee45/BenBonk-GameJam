using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int numberOfEnemies;
    private bool levelDone = false;
    public GameObject doors;
    public GameObject NPC;
    private GameObject currentNPC;

    private void Start()
    {
        doors.SetActive(false);
        NPC = GameObject.FindGameObjectWithTag("NPC");
        NPC.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (levelDone == false)
        {
            if (numberOfEnemies <= 0)
            {
                Debug.Log("Next Level");
                levelDone = true;
                loadDoors();
                loadNPC();
            }
        }
    }
    public void killEnemy() //when player kills an enemy this is called
    {
        numberOfEnemies--;
    }

    void loadDoors()
    {
        doors.SetActive(true);
    }

    void loadNPC()
    {
        Debug.Log("NPC Loaded");
        NPC.SetActive(true);
    }

    void killNPC()
    {
        Destroy(currentNPC);
        Debug.Log("NPC destroyed");
    }

    
}
