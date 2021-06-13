using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2_behavior : MonoBehaviour
{
    // Start is called before the first frame update
  private Vector3 _origPos;
    float horDir;
    float verDir;
    Vector2 horMove = new Vector2(1f, 0f);
    Vector2 verMove = new Vector2(0f, 1f);
    public GameObject player;
    public float speed;
    public Animator animator;
    public GameObject currentNode;
    public bool topped;
    public float R;
    public float G;
    public float B;

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

    public void NodeContact(GameObject contactedNode){
        topped = true;
        currentNode = contactedNode;
    }


}
