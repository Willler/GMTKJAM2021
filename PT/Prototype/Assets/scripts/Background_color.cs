using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_color : MonoBehaviour
{
    // Start is called before the first frame update
    public float R;
    public float G;
    public float B;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().color=new Color(R, G, B, 1);
    }

    public void ColorChange(float Red, float Green, float Blue){
        R += Red;
        G += Green;
        B += Blue;
        gameObject.GetComponent<SpriteRenderer>().color=new Color(R, G, B, 1);
    }

}
