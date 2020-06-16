using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //Configuration Parameters
    [SerializeField] Paddle paddle1;
    [SerializeField] float launchVectorX;
    [SerializeField] float launchVectorY;
    [SerializeField] AudioClip[] bounceSounds;
    [SerializeField] float randomBounceValue;
    ///[SerializeField]
    
    //State
    Vector2 paddleToBallVector;
    private bool hasStarted;

    //Cached component references
    AudioSource audioSource;
    Rigidbody2D myRigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        
        paddleToBallVector = transform.position - paddle1.transform.position;
        hasStarted = false;
        audioSource = GetComponent<AudioSource>();
        myRigidbody2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(UnityEngine.Random.Range(0f, randomBounceValue), UnityEngine.Random.Range(0f, randomBounceValue));
        myRigidbody2D.velocity += velocityTweak;
        PlayBallSound();
    }

    private void PlayBallSound()
    {
        System.Random randomClip = new System.Random();
        int clipToPlay = randomClip.Next(0, bounceSounds.Length);
        audioSource.clip = bounceSounds[clipToPlay];
        audioSource.PlayOneShot(audioSource.clip);
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            myRigidbody2D.velocity = new Vector2(launchVectorX, launchVectorY);
            //Debug.Log("Mouse button 0 pressed");
            hasStarted = true;
        }
    }

    private void LockBallToPaddle()
    {   
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }
}
