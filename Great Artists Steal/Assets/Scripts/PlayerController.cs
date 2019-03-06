using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2;
    [SerializeField] private float turnSpeed = 300;
    [SerializeField] private Animator animator;
    [SerializeField] private ParticleSystem bulbs;

    public int count;
    [SerializeField] private int winCount;
    //[SerializeField] private int loseCount = 0;
    //private Vector3 checkPoint;

    public Text counter;
    //public Image caught;

    void Start()
    {
        //caught.enabled = false;
        animator.SetBool("Grounded", true);
        //checkPoint = transform.position;
    }

    void Update()
    {
        if (count >= winCount)
        {
            SceneManager.LoadScene(0);
        }
        
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        animator.SetFloat("MoveSpeed", v);

        transform.position += transform.forward * v * moveSpeed * Time.deltaTime;
        transform.Rotate(0, h * turnSpeed * Time.deltaTime, 0);

    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("enter");
        if (other.gameObject.CompareTag("comp"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();
            bulbs.Play();
        }
    }

   /* private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("alarm"))
        {
            Debug.Log("caught");
            StartCoroutine(alarmTriggered());
        }
    }

    IEnumerator alarmTriggered()
    {
        caught.enabled = true;
        Debug.Log("caught2");
        loseCount++;
        yield return new WaitForSeconds(3);
        if (loseCount >= 3)
        {
            SceneManager.LoadScene(4);
        }
        else
        {
            transform.position = checkPoint;
            caught.enabled = false;
            //Scene loadedLevel = SceneManager.GetActiveScene();
            //SceneManager.LoadScene(loadedLevel.buildIndex);
        }
    }*/

    void SetCountText()
    {
        counter.text = count.ToString() + " Inspiration";
        if (count != 1)
        {
            counter.text += "s";
        }
    }
}
