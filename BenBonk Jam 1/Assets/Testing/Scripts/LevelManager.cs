using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int numberOfEnemies;
    private bool levelDone = false;
    public GameObject doors;

    private void Start()
    {
        doors.SetActive(false);
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
}
