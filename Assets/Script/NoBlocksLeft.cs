using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NoBlocksLeft : MonoBehaviour
{
    SceneLoader sceneLoader;
    // Start is called before the first frame update
    void Start()
    {
       sceneLoader = FindObjectOfType<SceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount == 0){
            sceneLoader.LoadNextScene();
        }
    }
}
