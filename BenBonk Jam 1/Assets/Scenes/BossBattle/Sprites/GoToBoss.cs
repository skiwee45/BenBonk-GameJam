using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToBoss : MonoBehaviour
{
    public GameObject pb;
    public GameObject b;
    public GameObject player;
    public GameObject reset;

    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Player")) {
            pb.SetActive(false);
            b.SetActive(true);
            player.transform.position = reset.transform.position;
         }
	}
}