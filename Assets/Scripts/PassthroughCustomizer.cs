using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassthroughCustomizer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private OVRPassthroughLayer passthroughLayer1;
    [SerializeField] private OVRPassthroughLayer passthroughLayer2;

    private bool isLayerActive = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float triggerPressure = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger);
        if (isLayerActive)
        {
            passthroughLayer1.SetBrightnessContrastSaturation(triggerPressure, 0, 0);
        }
        else
        {
            passthroughLayer2.SetBrightnessContrastSaturation(triggerPressure, 0, 0);
        }

        if(OVRInput.GetDown(OVRInput.Button.One))
        {
            ToggleCompositionDepth();
        }
    }
    private void ToggleCompositionDepth()
    {
        int tempDepth = passthroughLayer1.compositionDepth;
        passthroughLayer1.compositionDepth = passthroughLayer2.compositionDepth;
        passthroughLayer2.compositionDepth = tempDepth;

        isLayerActive = !isLayerActive;
    }
}
