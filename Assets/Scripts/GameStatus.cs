using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{

    //config parameters
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int PointsPerBlockDestroyed = 83;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI lifeText;
    [SerializeField] bool isAutoPlayEnabled;

    //state variables 
    [SerializeField] int currentScore = 0;
    public int currentLives = 5;


    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1) 
        {
            Destroy(gameObject);
        }
        else 
        {
            DontDestroyOnLoad(gameObject);
        }


    }

    private void Start()
    {
        scoreText.text = currentScore.ToString();
        lifeText.text = currentLives.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;

    }

    public void AddToScore()
    {
        currentScore += PointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }

    public void LoseLife()
    {
        currentLives = currentLives-1;
        lifeText.text = currentLives.ToString();
    }

    public void GainLife()
    {
        currentLives = currentLives+1;
        lifeText.text = currentLives.ToString();
    }

    public void RestartGame()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }

}
