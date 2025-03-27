using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


[RequireComponent(typeof(Rigidbody))]
public class randomWalk : MonoBehaviour
{
    [Header("Movement Settings")]
    [Tooltip("How fast the object will be pushed.")]
    public float moveSpeed = 3f;
    [Tooltip("Time interval (in seconds) between direction changes.")]
    public float changeDirectionInterval = 1f;

    [Header("Randomness Settings")]
    [Tooltip("Chance (0 to 1) that the object will stop moving on a direction change.")]
    [Range(0f, 1f)]
    public float stopProbability = 0.2f;

    public static int fishCaught = 0;

    // Current random direction on the horizontal plane (XZ).
    private Vector3 currentDirection;
    // Timer for tracking when to change direction.
    private float timer = 0f;
    // Reference to the Rigidbody component.
    private Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("No Rigidbody found on this GameObject!");
        }
        ChooseNewDirection();
        XRBaseInteractable interactable = GetComponent<XRBaseInteractable>();

        interactable.selectExited.AddListener(OnSelectExited);
    }

    void OnSelectExited(SelectExitEventArgs args)
    {
        moveSpeed = 0;
        fishCaught++;
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= changeDirectionInterval)
        {
            timer = 0f;
            ChooseNewDirection();
        }
        
        
    }

    void ChooseNewDirection()
    {
        // Decide whether to stop or move.
        if (Random.value < stopProbability)
        {
            currentDirection = Vector3.zero;
            rb.velocity = Vector3.zero;
        }
        else
        {
            // Choose a random angle in degrees for the XZ plane.
            float angle = Random.Range(0f, 360f);
            float rad = angle * Mathf.Deg2Rad;
            currentDirection = new Vector3(Mathf.Cos(rad), 0f, Mathf.Sin(rad)).normalized;

            // Reset any previous velocity and "push" the Rigidbody in the chosen direction.
            rb.velocity = Vector3.zero;
            rb.AddForce(currentDirection * moveSpeed, ForceMode.Impulse);
        }
    }

    
}


