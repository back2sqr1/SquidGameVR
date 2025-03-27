using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleport : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.gameObject.name);
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.transform.position += new Vector3(0, 30, 0);
            Debug.Log("Player has entered the portal");
        }
    }
}
