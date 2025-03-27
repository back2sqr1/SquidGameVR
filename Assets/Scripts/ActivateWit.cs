using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using Oculus.Voice;

public class ActivateWit : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject wall;
    // public AppVoiceExperience wit;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the wall
        // if (collision.gameObject == wall)
        // {
        //     // Activate Wit for voice recognition
        //     wit.Activate();
        //     Debug.Log("Collision with wall detected, Wit activated");
        // }
    }
}
