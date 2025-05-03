using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform playerTarget; // The player's camera
    public Transform mirror;       // The mirror's transform

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the reflection of the player's position relative to the mirror
        Vector3 mirrorNormal = mirror.forward; // Assuming the mirror's forward vector is its normal
        Vector3 toPlayer = playerTarget.position - mirror.position;
        Vector3 reflectedPosition = mirror.position - Vector3.Reflect(toPlayer, mirrorNormal);

        // Point the camera (this object) towards the reflected position
        transform.LookAt(reflectedPosition);
    }
}