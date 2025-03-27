using System.Collections;
using UnityEngine;

public class AudioRepeater : MonoBehaviour
{
    // Reference to the AudioSource component
    public AudioSource audioSource;

    // Time interval in seconds
    public float interval = 3f;

    void Start()
    {
        // If no AudioSource is assigned in the inspector, try to get it from the GameObject
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        // If an AudioSource is available, start the repeating playback coroutine
        if (audioSource != null)
        {
            StartCoroutine(PlayAudioEveryInterval());
        }
        else
        {
            Debug.LogError("No AudioSource found on this GameObject.");
        }
    }

    // Coroutine to play the audio every specified interval
    IEnumerator PlayAudioEveryInterval()
    {
        while (true)
        {
            audioSource.Play();
            yield return new WaitForSeconds(interval);
        }
    }
}
