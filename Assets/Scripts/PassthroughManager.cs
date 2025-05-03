using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassthroughManager : MonoBehaviour
{
    [SerializeField] private OVRPassthroughLayer passthroughLayer1;
    [SerializeField] protected OVRPassthroughLayer passthroughLayer2;

    private bool isLayerActive = true;

    private void Update()
    {
        float triggerPressure = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger);
        if(isLayerActive)
        {
            passthroughLayer1.SetBrightnessContrastSaturation(triggerPressure, 0, 0);
        }
        else
        {
            passthroughLayer1.SetBrightnessContrastSaturation(triggerPressure, 0, 0);
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
