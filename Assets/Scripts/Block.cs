using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    //config params
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] int MaxHits;
    [SerializeField] Sprite[] hitSprites;


    //cached reference
    level level;
    GameStatus GameStatus;


    //state variables
    [SerializeField] int timesHit;
    private void Start()
    {
        CountBreakableBlocks();
        GameStatus = FindObjectOfType<GameStatus>();

    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<level>();
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++;
        if (timesHit >= MaxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();

        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }

    private void DestroyBlock()
    {
        PlayBlockDestroySFX();
        level.BlockDestroyed();
        GameStatus.AddToScore();
        TriggerSparklesVFX();
    }

    private void PlayBlockDestroySFX()
    {
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    private void TriggerSparklesVFX() 
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}

