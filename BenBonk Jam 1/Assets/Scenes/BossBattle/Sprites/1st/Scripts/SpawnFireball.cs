using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFireball : MonoBehaviour
{
    public GameObject fireballPrefab;
    public GameObject[] spawns;
    private GameObject currentPoint;
    int index;
    public float spawnTime = 0.1f;
    public bool firstStage = true;

    public AudioSource fire;
    public AudioSource transformNext;

    public GameObject HealthBar;

    void Start()
    {
        StartCoroutine(fireballWaves());
    }

    private void spawnFireball()
    {
        fire.Play();
        index = Random.Range (0, spawns.Length);
        currentPoint = spawns[index];
        GameObject a = Instantiate(fireballPrefab) as GameObject;
        a.transform.position = new Vector2(currentPoint.transform.position.x, currentPoint.transform.position.y);
	}
    
    IEnumerator fireballWaves(){
        while(firstStage == true){
            yield return new WaitForSeconds (spawnTime);
            spawnFireball();  
		}
	}

    public void GetDamage(int damage){
        HealthBar.GetComponent<Stage1Health>().TakeDamage(1);
	}

    public void NextStage(GameObject boss, GameObject another){
        transformNext.Play();
        boss.SetActive(false);
        another.SetActive(true);
	}

}
