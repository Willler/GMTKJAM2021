using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player_behavior : MonoBehaviour
{
    private Vector3 _origPos;
    float horDir;
    float verDir;
    Vector2 horMove = new Vector2(1f, 0f);
    Vector2 verMove = new Vector2(0f, 1f);
    public GameObject player;
    public float speed;
    public Animator animator;
    GameObject currentNode;
    GameObject otherNode;
    LineRenderer lr;
    GameObject otherPlayer;
    public bool topped; 
    bool drawn1;
    bool drawn2;
    public float R;
    public float G;
    public float B;
    public GameObject rope1;
    public GameObject rope2;
    public GameObject rope3;
    public GameObject rope4;
    public GameObject rope5;
    public GameObject rope6;
    public GameObject leftBG;
    public GameObject rightBG;
    public float colorModifier = .25f;
    public float greenColorMod;
    bool colorChangerActive = false;



    private void Awake() {
        lr = GetComponent<LineRenderer>();
        otherPlayer = GameObject.FindGameObjectWithTag("Player2");
    }

    void Start()
    {
        _origPos = transform.position;
        gameObject.GetComponent<SpriteRenderer>().color=new Color(R, G, B, 1);
    }

    // Update is called once per frame
    void Update()
    {
        horDir = Input.GetAxisRaw("Horizontal");
        verDir = Input.GetAxisRaw("Vertical");
        Movement();
        LineManagement();
    }

    void Movement(){
        if(horDir !=0 ||verDir !=0){
            player.GetComponent<Rigidbody2D>().position += (horMove * horDir * speed * Time.deltaTime);
            player.GetComponent<Rigidbody2D>().position += (verMove * verDir * speed * Time.deltaTime);
            Vector3 moveDirection = gameObject.transform.position - _origPos;
            if (moveDirection != Vector3.zero)
            {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg - 90; 
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
            animator.SetTrigger("Swimming");
        } else{
            animator.SetTrigger("Not_Swimming");
        }
    }

    void LineManagement(){
        lr.SetPosition(0, player.GetComponent<Rigidbody2D>().position);
        lr.SetPosition(1, otherPlayer.GetComponent<Rigidbody2D>().position);
        if(drawn2){

        }
    }

    public void NodeContact(GameObject contactedNode){
        currentNode = contactedNode;
        if(otherPlayer.GetComponent<Player2_behavior>().topped){
            if(otherPlayer.GetComponent<Player2_behavior>().currentNode.GetComponent<Node_Behavior>().iden == currentNode.GetComponent<Node_Behavior>().iden){
                topped = true;
                otherNode = otherPlayer.GetComponent<Player2_behavior>().currentNode;
                if(currentNode.GetComponent<Node_Behavior>().iden == 1){
                    rope1.SetActive(true);
                    colorChangerActive = true;
                    ColorChangeBG();
                }
                if(currentNode.GetComponent<Node_Behavior>().iden == 2){
                    rope2.SetActive(true);
                    colorChangerActive = true;
                    ColorChangeBG();
                }
                if(currentNode.GetComponent<Node_Behavior>().iden == 3){
                    rope3.SetActive(true);
                    colorChangerActive = true;
                    ColorChangeBG();
                }
                if(currentNode.GetComponent<Node_Behavior>().iden == 4){
                    rope4.SetActive(true);
                    colorChangerActive = true;
                    ColorChangeBG();
                }
                if(currentNode.GetComponent<Node_Behavior>().iden == 5){
                    rope5.SetActive(true);
                    colorChangerActive = true;
                    ColorChangeBG();
                }
                if(currentNode.GetComponent<Node_Behavior>().iden == 6){
                    rope6.SetActive(true);
                    colorChangerActive = true;
                    ColorChangeBG();
                }
            }
        }
    }
    void ColorChangeBG(){
        if(colorChangerActive){
            float R = colorModifier;
            float G = greenColorMod;
            float B = -colorModifier;
            leftBG.GetComponent<Background_color>().ColorChange(R,G,B);
            rightBG.GetComponent<Background_color>().ColorChange(B,-G,R);
            colorChangerActive = false;
        }
    }

}    

