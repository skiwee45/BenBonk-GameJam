using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToBos : MonoBehaviour
{
    public GameObject pb;
    public GameObject boss;
    public Transform reset;
    public Transform player;

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("win")){
              pb.SetActive(false);
              boss.SetActive(true);
              player.position = reset.position;
		}
	}
}
