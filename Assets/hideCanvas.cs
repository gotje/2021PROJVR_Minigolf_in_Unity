using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class hideCanvas : MonoBehaviour
{
    private InputDevice controller;
    private Renderer r;

    // Start is called before the first frame update
    void Start()
    {
        List<InputDevice> devices = new List<Inputdevice>();
        InputDeviceCharacteristics leftControllerCharacteristics = InputDeviceCharacteristics.Left | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(leftControllerCharacteristics devices);
        if(devices.Count > 0)
        {
            controller = devices[0];
            Debug.log("device added");
        }
        r = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        targetDevice.TryGetFeatureValue(CommonUsages.grip, out float state);
        if (state > 0.5f)
        {
            ShowCanvas();
        }
        else
        {
            HideCanvas();
        }
    }

    private void ShowCanvas()
    {
        r.enabled = true;
    }

    private void HideCanvas()
    {
        r.enabled = false;
    }
}
