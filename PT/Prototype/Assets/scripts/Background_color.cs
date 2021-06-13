using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Background_color : MonoBehaviour
{
    // Start is called before the first frame update
    public float R;
    public float G;
    public float B;

    public GameObject TransitionFlow;
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

    private void Update() {
        
        if (Mathf.Approximately(R, B))
        {
            TransitionFlow.SetActive(true);
        }
        else if (Mathf.Approximately(R, 0.53f) && Mathf.Approximately(G, 0.2f) && Mathf.Approximately(B, 0.27f))
        {
            
            Debug.Log("Transitioning");
            TransitionFlow.SetActive(true);
        }
    }

}
