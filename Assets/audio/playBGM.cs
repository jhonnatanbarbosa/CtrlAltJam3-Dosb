using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playBGM : MonoBehaviour
{
    public AudioSource audioSource2; // Reference to the second AudioSource component
    public AudioClip thirdClip;   // Reference to the third audio clip
    private float timeSinceStart = 0; // Time since the script started
    private bool hasPlayed = false; // To check if the clip has been played

    private void Update()
    {
        timeSinceStart += Time.deltaTime;

        if (timeSinceStart > 2f && !hasPlayed)
        {
            // Play the third clip after the first and second clips have finished
            if (thirdClip != null && audioSource2 != null)
            {
                audioSource2.clip = thirdClip;
                audioSource2.Play();
                hasPlayed = true; // Ensure it only plays once
            }
            else
            {
                Debug.LogWarning("AudioSource or AudioClip is not assigned.");
            }
        }
    }
}
