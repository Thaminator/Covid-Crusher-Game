using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoPlay : MonoBehaviour
{
    //cached reference

    GameStatus theGameStatus;

    private void Awake()
    {
        theGameStatus = FindObjectOfType<GameStatus>();
        theGameStatus.EnableAutoPlay();
        theGameStatus.FastGameSpeed();
    }




}
