using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CollectItem : MonoBehaviour
{
    // Start is called before the first frame update
    public ContinuousMoveProviderBase  moveProvider;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Entered");
        if (other.gameObject.CompareTag("Lightning"))
        {
            // Add the item to the player's inventory
            moveProvider.moveSpeed += 1f; // Example: Increase the player's speed
            // For example, you can call a method on the player script to add the item
            Debug.Log("Item collected!");

            Destroy(other.gameObject); // Destroy the item after collection
        }
    }
}
