using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    // Start is called before the first frame update

    public Text startMenuText;

    void Start()
    {
        
    }

    public void onPointerEnter()
    {

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
}
