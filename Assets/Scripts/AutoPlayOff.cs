using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoPlayOff : MonoBehaviour
{
    //cached reference

    GameStatus theGameStatus;

    private void Awake()
    {
        theGameStatus = FindObjectOfType<GameStatus>();
        theGameStatus.DisableAutoPlay();
        theGameStatus.NormalGameSpeed();

    }




}
