using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    //cached reference
    SaveGame theSaveGame;
    GameStatus theGameStatus;


    int lastSave;

    private void Start()
    {
        theSaveGame = FindObjectOfType<SaveGame>();
        theGameStatus = FindObjectOfType<GameStatus>();
    }



    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadMLScene()
    {
        SceneManager.LoadScene("AutoLevel");
    }

    public void LoadCurrentScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadFirstScene()
    {
        theGameStatus.ResetLife();
        SceneManager.LoadScene(1);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameStatus>().RestartGame();
    }

    public void LoadSavedScene()
    {
        GetLastSave();
        
        SceneManager.LoadScene(lastSave);
    }

    public void GetLastSave()
    {
        
     lastSave = theSaveGame.savedSceneIndex;
    }

    public void Quit()
    {
        Application.Quit();
    }

    
}
