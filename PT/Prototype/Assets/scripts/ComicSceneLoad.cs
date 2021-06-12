using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;

public class ComicSceneLoad : MonoBehaviour
{

    public Flowchart LoadSceneFlow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool finishedIntroComic = LoadSceneFlow.GetBooleanVariable("ComicRead");

        if (finishedIntroComic == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
