using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScytheShooting : MonoBehaviour
{
    public bool firstStage = true;
    
    public Transform firePoint;
    public GameObject scythePrefab;

    public float scytheForce = 20f;
    public float spawnTime = 1f;

    void Start()
    {
        StartCoroutine(scytheWave());
    }

    void spawnSycthe(){
        GameObject scythe = Instantiate(scythePrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = scythe.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * scytheForce, ForceMode2D.Impulse);
	}

    IEnumerator scytheWave(){
        while(firstStage == true){
            yield return new WaitForSeconds (spawnTime);
            spawnSycthe();  
		}
	}

}
