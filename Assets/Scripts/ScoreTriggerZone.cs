using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTriggerZone : MonoBehaviour
{
    bool active = true;
    public AudioClip scoreSound;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (active && collision.gameObject.CompareTag("Player"))
        {
            active = false;

            if (scoreSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(scoreSound);
            }

            ScoreManager.score++;

            Destroy(gameObject, 0.5f);
        }
    }
}
