using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using static UnityEngine.Input;

public class hideCanvas : MonoBehaviour
{
    private Renderer r;
    public InputDevice controller;

    // Start is called before the first frame update
    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics leftControllerCharacteristics = InputDeviceCharacteristics.Left | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(leftControllerCharacteristics, devices);
        if(devices.Count > 0)
        {
            controller = devices[0];
        }
        r = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //float state = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, controller);
        
        controller.TryGetFeatureValue(CommonUsages.grip, out float state);
        if (state > 0.5f)
        {
            ShowCanvas();
        }
        else
        {
            DissapearCanvas();
        }
    }

    private void ShowCanvas()
    {
        r.enabled = true;
    }

    private void DissapearCanvas()
    {
        r.enabled = false;
    }
}
