using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line_Controller : MonoBehaviour
{
    private LineRenderer lr;
    public GameObject player;
    bool playerLined = false;
    // Start is called before the first frame update
    private void Awake() {
     lr = GetComponent<LineRenderer>();   
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            if(player.GetComponent<Player_behavior>().lined == false){
                player.GetComponent<Player_behavior>().LineMe();
                playerLined = true;
            }
        }
    }
    
    private void Update() {
        if(playerLined){
            lr.SetPosition(0, player.GetComponent<Rigidbody2D>().position);
        }
    }

}
