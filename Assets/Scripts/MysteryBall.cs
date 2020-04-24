using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysteryBall : MonoBehaviour
{
    //config params
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactorX = 10f;
    [SerializeField] float randomFactorY = 4f;


    //state
    Vector2 paddleToBallVector;
    bool hasStarted = false;

    //Cached component references
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2D;



    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!hasStarted)
        {
            LockBalltoPaddle();
            LaunchBallonMouseClick();
        }
    }

    private void LaunchBallonMouseClick()
    {
        if (Input.GetMouseButton(0))
        {
               hasStarted = true;
            myRigidBody2D.velocity = new Vector2(xPush, yPush);
        
        }
    }

    private void LockBalltoPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2
            (UnityEngine.Random.Range(-2, randomFactorX), 
            UnityEngine.Random.Range(-2, randomFactorY));

        if (hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0,ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            myRigidBody2D.velocity += velocityTweak;
        }
    }


}
