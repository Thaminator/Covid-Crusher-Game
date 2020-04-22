using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level : MonoBehaviour
{
    //parameters
    [SerializeField] int breakableBlocks; //Serialized for debugging purposes

    //cached reference
    SceneLoader sceneloader;
    GameStatus theGameStatus;

    private void Start()
    {
        sceneloader = FindObjectOfType<SceneLoader>();
        theGameStatus = FindObjectOfType<GameStatus>();
    }

    public void CountBlocks()
    {
        breakableBlocks++;

    }
    
    public void BlockDestroyed()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0)
        {
            theGameStatus.GainLife();
            sceneloader.LoadNextScene();
        }
    }
}
