using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SecuritySystem : MonoBehaviour
{

    [SerializeField] private int loseCount = 0;
    private Vector3 checkPoint;
    private bool catching = true;

    public Image caught;
    [SerializeField] private PlayerController student;

    [SerializeField] private Camera firstCam;
    [SerializeField] private Camera secondCam;
    [SerializeField] private Camera thirdCam;

    [SerializeField] private GameObject firstLight;
    [SerializeField] private GameObject secondLight;
    [SerializeField] private GameObject thirdLight;


    // Start is called before the first frame update
    void Start()
    {
        caught.enabled = false;
        checkPoint = transform.position;

        secondCam.enabled = false;
        secondLight.SetActive(false);
        thirdCam.enabled = false;
        thirdLight.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("alarm") && catching && student.visible)
        {
            catching = false;
            Debug.Log("caught");
            StartCoroutine(AlarmTriggered());
        }
        if (other.CompareTag("room1") )
        {
            Debug.Log("tag");
            CamSwitch(firstCam, firstLight);
        }
        if (other.CompareTag("room2") )
        {
            Debug.Log("tag");
            CamSwitch(secondCam, secondLight);
        }
        if (other.CompareTag("room3"))
        {
            Debug.Log("tag");
            CamSwitch(thirdCam, thirdLight);
        }
    }

    IEnumerator AlarmTriggered()
    {
        caught.enabled = true;

        Debug.Log("caught2");
        loseCount++;
        yield return new WaitForSeconds(3);
        catching = true;
        if (loseCount >= 3)
        {
            SceneManager.LoadScene(5);
        }
        else
        {
            transform.position = checkPoint;
            caught.enabled = false;
        }
    }

    public void CamSwitch(Camera cNext, GameObject lNext)
    {
        firstCam.enabled = false;
        secondCam.enabled = false;
        thirdCam.enabled = false;

        firstLight.SetActive(false); 
        secondLight.SetActive(false);
        thirdLight.SetActive(false);

        cNext.enabled = true;
        lNext.SetActive(true);
    }
}
