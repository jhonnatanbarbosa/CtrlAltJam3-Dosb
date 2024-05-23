using UnityEngine;

public class SequentialAudioPlayer : MonoBehaviour
{
    public AudioClip firstClip;   // Reference to the first audio clip
    public AudioClip secondClip;  // Reference to the second audio clip

    public AudioSource audioSource;

    void Start()
    {
        // Get the AudioSource component attached to the GameObject
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            // If there is no AudioSource component, add one
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Start playing the first clip
        PlayFirstClip();
    }

    void PlayFirstClip()
    {
        if (firstClip != null)
        {
            audioSource.clip = firstClip;
            audioSource.loop = false; // Ensure the first clip does not loop
            audioSource.Play();
            Invoke("PlaySecondClip", firstClip.length); // Schedule the second clip to play after the first one ends
        }
    }

    void PlaySecondClip()
    {
        if (secondClip != null)
        {
            audioSource.clip = secondClip;
            audioSource.loop = true; // Ensure the second clip loops
            audioSource.Play();
        }
    }
}
