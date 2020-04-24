using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle2 : MonoBehaviour
{

    //cached references
    Paddle thePaddle;

    void Start()
    {
        thePaddle = FindObjectOfType<Paddle>();
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = (thePaddle.transform.position.x) + 5;
        transform.position = paddlePos;
    }


    void Update()
    {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = (thePaddle.transform.position.x)+5;
        transform.position = paddlePos;
    }


}
