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
    public float horMod;
    public float verMod;
    public Animator animator;
    public GameObject currentNode;
    bool drawing = false;
    GameObject previousNode;
    LineRenderer lr;
    bool drawn = false;

    private void Awake() {
     lr = GetComponent<LineRenderer>();   
    }

    void Start()
    {
        _origPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        horDir = Input.GetAxisRaw("Horizontal") * horMod;
        verDir = Input.GetAxisRaw("Vertical") * verMod;
        Movement();
        LineManagement();
    }

    void Movement()
    {
        player.GetComponent<Rigidbody2D>().position += (horMove * horDir * speed * Time.deltaTime);
        player.GetComponent<Rigidbody2D>().position += (verMove * verDir * speed * Time.deltaTime);
        Vector3 moveDirection = gameObject.transform.position - _origPos;
        if (moveDirection != Vector3.zero)
        {
           float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg - 90; 
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            animator.SetTrigger("Swimming");
        }
    }

    void LineManagement(){
        if(drawing){
            lr.SetPosition(0, currentNode.GetComponent<Rigidbody2D>().position);
            lr.SetPosition(1, player.GetComponent<Rigidbody2D>().position);
        }
        else if(drawn){
            lr.SetPosition(0, previousNode.GetComponent<Rigidbody2D>().position);
            lr.SetPosition(1, currentNode.GetComponent<Rigidbody2D>().position);
        }
    }

    public void NodeContact(GameObject contactedNode){
        if(!drawing){
            drawing = true;
            currentNode = contactedNode;
        }
        else if (drawing){
            previousNode = currentNode;
            currentNode = contactedNode;
            drawing = false;
            drawn = true;
        }
    }

}    

