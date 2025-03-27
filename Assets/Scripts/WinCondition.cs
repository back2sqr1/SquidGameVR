using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject a, b, c;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if any of the three objects are really close to each other, then the player wins
        float win_distance = 0.5f;
        if (Vector3.Distance(a.transform.position, b.transform.position) < win_distance ||
            Vector3.Distance(b.transform.position, c.transform.position) < win_distance ||
            Vector3.Distance(c.transform.position, a.transform.position) < win_distance)
        {
            // get timer component
            Timer timer = gameObject.GetComponent<Timer>();
            timer.status = 1;
            timer._timerActive = false;
            Debug.Log("You Win!");
        }
    }
}
