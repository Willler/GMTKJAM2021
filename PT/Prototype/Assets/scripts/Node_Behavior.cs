using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node_Behavior : MonoBehaviour
{
    GameObject player;
    public GameObject rope;
    public GameObject self;
    public int iden = 1;

    private void OnTriggerStay2D(Collider2D other) {
        if(!rope.activeSelf){
            if(other.tag == "Player"){
                player = other.gameObject;
                player.GetComponent<Player_behavior>().NodeContact(self);
            }
            if(other.tag == "Player2"){
                player = other.gameObject;
                player.GetComponent<Player2_behavior>().NodeContact(self);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player"){
            player = other.gameObject;
            player.GetComponent<Player_behavior>().topped = false;
        }
        if(other.tag == "Player2"){
            player = other.gameObject;
            player.GetComponent<Player2_behavior>().topped = false;
        }
    }
    
}

    

