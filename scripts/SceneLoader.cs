using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    //GameStatus gameStatus;

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
        //gameStatus = FindObjectOfType<GameStatus>();
        //gameStatus.FindTextForScore();
        //gameStatus.ResetGameSpeed();

    }

    public void LoadStartScene()
    {
        
        SceneManager.LoadScene(0);
        FindObjectOfType<GameSession>().DestroyOnLose();
        //gameStatus = FindObjectOfType<GameStatus>();
        //gameStatus.FindTextForScore();
        //gameStatus.ResetGameSpeed();

    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("The game has quit");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
 

}
