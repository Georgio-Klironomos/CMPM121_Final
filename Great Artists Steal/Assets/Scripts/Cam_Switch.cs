using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_Switch : MonoBehaviour
{
    public Camera first;
    public Camera second;
    bool cam = false;

    void Start()
    {
        second.enabled = false;
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("trigger");
        // Change the cube color to green.
        if (collision.CompareTag("Player"))
        {
            Debug.Log("tag");
            CamSwitch();
        }
    }

    public void CamSwitch()
    {
        first.enabled = cam;
        second.enabled = !cam;
        cam = !cam;
    }
}
