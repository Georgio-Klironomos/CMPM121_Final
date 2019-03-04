using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_Switch : MonoBehaviour
{
    [SerializeField] private Camera firstCam;
    [SerializeField] private Camera secondCam;
    [SerializeField] private GameObject firstLight;
    [SerializeField] private GameObject secondLight;


    bool camSwitch = false;

    void Start()
    {
        secondCam.enabled = false;
        secondLight.SetActive(false);
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
        firstCam.enabled = camSwitch;
        secondCam.enabled = !camSwitch;
        firstLight.SetActive(camSwitch);
        secondLight.SetActive(!camSwitch);

        camSwitch = !camSwitch;
    }
}
