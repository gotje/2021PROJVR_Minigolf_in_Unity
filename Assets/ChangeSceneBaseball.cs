using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class ChangeSceneBaseball : MonoBehaviour
{
    public XRController leftTeleportRay;
    public XRController rightTeleportRay;
    public float activationTreshold = 0.1f;
    public XRRayInteractor leftInteractorRay;
    public XRRayInteractor rightInteractorRay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3();
        Vector3 norm = new Vector3();
        bool validTarget = false;
        int index = 0;
        if (leftTeleportRay)
        {
            bool isLeftInteractorRayHovering = leftInteractorRay.TryGetHitInfo(ref pos, ref norm, ref index, ref validTarget);
            if (isLeftInteractorRayHovering)
            {
                Debug.Log("interaction");
                SceneManager.LoadScene("baseball");
            }
        }
        if (rightTeleportRay)
        {
            bool isLeftInteractorRayHovering = rightInteractorRay.TryGetHitInfo(ref pos, ref norm, ref index, ref validTarget);
            if (isLeftInteractorRayHovering)
            {
                Debug.Log("interaction");
                SceneManager.LoadScene("Minigolf");
            }
        }
    }

    public void LoadSceneBaseball()
    {
        SceneManager.LoadScene("baseball");

    }

    public void LoadSceneMinigolf()
    {
        SceneManager.LoadScene("Minigolf");
    }
}
