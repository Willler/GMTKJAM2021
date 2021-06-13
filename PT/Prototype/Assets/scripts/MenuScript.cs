using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    // Start is called before the first frame update

    public Text startMenuText;
    public AudioSource highlight;

    void Start()
    {
        highlight = GetComponent<AudioSource>();
    }

    public void onPointerEnter()
    {
        highlight.Play();
    }

    // Update is called once per frame
    void Update()

    {
        
    }

   public void nextSceneButton()
    {
        StartCoroutine("nextSceneRoutine");
        
        
    }

    IEnumerator nextSceneRoutine()
    {
        yield return new WaitForSeconds(2f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void endGame()
    {
        Debug.Log("ending");
        Application.Quit(); 
    }
}
