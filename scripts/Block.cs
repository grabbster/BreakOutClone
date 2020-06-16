using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Block : MonoBehaviour
{
    // Config Params
    [SerializeField] AudioClip[] destroySound;
    [SerializeField] GameObject sparklesVFX;
    [SerializeField] Sprite[] hitSprites;

    // Cached References
    AudioSource audioSource;
    GameSession gameStatus;
    Level level;

    // State Variables
    [SerializeField] int timesHit; //only serial for debug
    




    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gameStatus = FindObjectOfType<GameSession>();

        CountBreakableBlocks();

    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        

        if (tag == "Breakable")
        {
            timesHit++;
            int maxHits = hitSprites.Length + 1;
            //ShowNextHitSprite();
            if (timesHit >= maxHits)
            {
                HandleHit();
            }
            else
            {
            PlayBlockBreakSFX();
            ShowNextHitSprite();
            }
        }
        
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null) 
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];

        }
        else
        {

            Debug.Log("Block sprite is missing from array on;"+ gameObject.name );
        }
    }

    private void HandleHit()
    {
        //Debug.Log("Block desutoyaaah");
        DestroyBlock();
        level.SubtractBreakableBlocks();
    }

    private void DestroyBlock()
    {
        
        PlayBlockBreakSFX();
        TriggerSparklesVFX();
        UpdateGameStatus();
        Destroy(gameObject);
    }

    private void UpdateGameStatus()
    {
        gameStatus = FindObjectOfType<GameSession>();

        gameStatus.gameSpeed = gameStatus.gameSpeed + gameStatus.speedIncrement;
        gameStatus.AddToScore();
        gameStatus.DisplayScore();
    }

    private void PlayBlockBreakSFX()
    {
        System.Random randomClip = new System.Random();
        int clipToPlay = randomClip.Next(0, destroySound.Length);
        audioSource.clip = destroySound[clipToPlay];

        AudioSource.PlayClipAtPoint(audioSource.clip, new Vector3(transform.position.x, transform.position.y, transform.position.z));
        
    }

    void OnEnable()
    {
        //Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled.
        //Remember to always have an unsubscription for every delegate you
        //subscribe to!
                       SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        gameStatus = FindObjectOfType<GameSession>();
        //Debug.Log("Level Loaded");
        //Debug.Log(scene.name);
        //Debug.Log(mode);
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(sparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1);
    }

}
