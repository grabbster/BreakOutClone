using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    [SerializeField] string levelToLoadOnLose;

    //GameStatus gameStatus;

    private void Awake()
    {
        //gameStatus = FindObjectOfType<GameStatus>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //gameStatus.DestroyOnLose();
        SceneManager.LoadScene(levelToLoadOnLose);

    }
}
