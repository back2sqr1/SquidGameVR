using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySong : MonoBehaviour
{
    [SerializeField] public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        // Make sure we have a reference to an AudioSource
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void PlaySongNow(string values)
    {
        Debug.Log("Playing song: " + values);
        if (audioSource != null && values == "Music")
        {
            audioSource.Play();
        }
        else
        {
            Debug.LogError("No AudioSource assigned to PlaySong component!");
        }
    }

    // Set the audio source at runtime if needed
    public void SetAudioSource(AudioSource source)
    {
        audioSource = source;
    }
}
