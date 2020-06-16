using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    //Config params
    [Range(0.1f, 10f)] [SerializeField] public float gameSpeed = 1f;
    [Range(0.1f, 10f)] [SerializeField] public float initialGameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 32;
    [Range(0.001f, 0.5f)] [SerializeField] public float speedIncrement = 0.025f;
    [SerializeField] bool autoPlayON;

    //State variables
    [SerializeField] int currentScore = 0;

    [SerializeField] TextMeshProUGUI scoreText;
    //private TextMeshProUGUI scoreText;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText = FindObjectOfType<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }
    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
    }
    public void DisplayScore()
    {
        scoreText = FindObjectOfType<TextMeshProUGUI>();
        string scoreToDisplay = currentScore.ToString();
        scoreText.text = scoreToDisplay;
    }
    /*
    public void FindTextForScore()
    {
        //scoreText = FindObjectOfType<TextMeshProUGUI>();
        scoreText = GetComponentInChildren<TextMeshProUGUI>();
        Debug.Log("text was looked for");
    }

    public void ResetGameSpeed()
    {
        gameSpeed = initialGameSpeed;
    }
    */

    public void DestroyOnLose()
    {
        Destroy(gameObject);
    }
  
   public bool IsAutoPlayEnabled()
    {
        return autoPlayON;
    }

}
