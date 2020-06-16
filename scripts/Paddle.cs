using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    //config params
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float paddlePositionMin = -5.57f;
    [SerializeField] float paddlePositionMax = 5.57f;
    bool autoplay;

    // cached references
    GameSession gameSession;
    Ball theBall;

    // Start is called before the first frame update
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        theBall = FindObjectOfType<Ball>();
        autoplay = gameSession.IsAutoPlayEnabled();
    }

    // Update is called once per frame
    void Update()
    {
      //  Debug.Log("mouse position is:" + Input.mousePosition.x / Screen.width * screenWidthInUnits);

        float mousePositionInUnits = ((Input.mousePosition.x / 2) / Screen.width * screenWidthInUnits);
        Vector2 paddlePostition = new Vector2(transform.position.x, transform.position.y);
        float paddlePositionX = Mathf.Clamp(GetXPos(), paddlePositionMin, paddlePositionMax);
        paddlePostition.x = paddlePositionX;
        transform.position = paddlePostition;
    }

    private float GetXPos()
    {
        if(autoplay == true)
        {
            return theBall.transform.position.x;
        }
        else
        {
            return ((Input.mousePosition.x / 2) / Screen.width * screenWidthInUnits);
        }
    }
}
