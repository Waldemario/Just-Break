using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakbleBlocks;
    SceneLoader sceneLoader;

	private void Start()
	{
        sceneLoader = FindObjectOfType<SceneLoader>();
	}

	public void CountBreakableBlocks()
    {
        breakbleBlocks++;
    }

    public void BlockDestroyed()
    {
        breakbleBlocks--;
        if (breakbleBlocks <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
