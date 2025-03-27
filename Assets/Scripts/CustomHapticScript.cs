using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[System.Serializable]
public class  Haptic 
{
    [Range(0, 1)]
    public float intensity = 0.5f;
    public float duration = 0.1f;
    public void TriggerHaptic(BaseInteractionEventArgs args)
    {
        if (args.interactorObject is XRBaseControllerInteractor controller)
        {
            TriggerHaptic(controller.xrController);
        }
    }

    // Update is called once per frame
    public void TriggerHaptic(XRBaseController controller)
    {
        if (intensity > 0)
        {
            controller.SendHapticImpulse(intensity, duration);
        }
    }
}

public class CustomHapticScript : MonoBehaviour
{
    // Start is called before the first frame update 
    public Haptic hapticOnActivated;
    public Haptic hapticHoverEntered;
    public Haptic hapticOnHoverExited;
    public Haptic hapticOnSelectEntered;
    public Haptic hapticOnSelectExited;
    void Start()
    {
        XRBaseInteractable interactable = GetComponent<XRBaseInteractable>();
        interactable.activated.AddListener(hapticOnActivated.TriggerHaptic);
        interactable.hoverEntered.AddListener(hapticHoverEntered.TriggerHaptic);
        interactable.hoverExited.AddListener(hapticOnHoverExited.TriggerHaptic);
        interactable.selectEntered.AddListener(hapticOnSelectEntered.TriggerHaptic);
        interactable.selectExited.AddListener(hapticOnSelectExited.TriggerHaptic);

    }


}
