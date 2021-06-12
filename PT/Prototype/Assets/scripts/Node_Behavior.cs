using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node_Behavior : MonoBehaviour
{
    GameObject player;
    public GameObject self;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            player = other.gameObject;
            player.GetComponent<Player_behavior>().NodeContact(self);
           
        }
    }
    
}
