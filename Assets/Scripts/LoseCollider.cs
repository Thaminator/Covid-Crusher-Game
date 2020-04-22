using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class LoseCollider : MonoBehaviour
{

    //cached reference

    GameStatus theGameStatus;
    SceneLoader theSceneLoader;

    private void Start()
    {
        theGameStatus = FindObjectOfType<GameStatus>();
        theSceneLoader = FindObjectOfType<SceneLoader>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(theGameStatus.currentLives <= 1)
        {
            SceneManager.LoadScene("Game Over");
        }

        else
        {
            theGameStatus.LoseLife();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }


    }



}
