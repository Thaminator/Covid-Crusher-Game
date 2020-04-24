using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveGame : MonoBehaviour
{

    public int savedSceneIndex;

    private void Awake()
    {
        int saveGameCount = FindObjectsOfType<SaveGame>().Length;
        if (saveGameCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    

    public void SaveTheGame()
    {
        int savedSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(savedSceneIndex);
    }

    public void LoadSavedScene()
    {
        SceneManager.LoadScene(savedSceneIndex);
    }



}
