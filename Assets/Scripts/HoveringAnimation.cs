using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HoveringAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 1f;
    public float height = 0.5f;
    private Vector3 startPos;

    void Awake()
    {
        startPos = transform.position;
    }

    void Start()
    {
        // Any additional initialization if needed
    }

    // Update is called once per frame
    void Update()
    {
        float yOffset = Mathf.Sin(Time.time * speed) * height;
        transform.position = startPos + new Vector3(0f, yOffset, 0f);
    }

}
