using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
public class MovementManager : MonoBehaviour
{
    private float xInput;
    private float yInput;
    private float movementSpeed = 10.0f;

    private InputData inputData;
    [SerializeField] private GameObject myObjectToMove;
    private Rigidbody myRB;
    private Transform myXRRig;
    // Start is called before the first frame update
    void Start()
    {
        myRB = myObjectToMove.GetComponent<Rigidbody>();
        GameObject myXROrigin = GameObject.Find("XR Origin");
        myXRRig = myXROrigin.transform;
        inputData = myXROrigin.GetComponent<InputData>();
    }

    // Update is called once per frame
    void Update()
    {
        myXRRig.position = myObjectToMove.transform.position;
        if(inputData.rightController.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 movement))
        {
            xInput = movement.x;
            yInput = movement.y;
        }
    }

    private void FixedUpdate() {
        myRB.AddForce(xInput * movementSpeed, 0, yInput * movementSpeed);
    }
}
