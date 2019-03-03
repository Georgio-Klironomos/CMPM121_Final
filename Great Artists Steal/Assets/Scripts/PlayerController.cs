using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2;
    [SerializeField] private float turnSpeed = 200;
    [SerializeField] private Animator animator;
    [SerializeField] private ParticleSystem bulbs;

    public int count;
    [SerializeField] private int winCount;

    public Text counter;
    public Image caught;

    void Start()
    {
        //gameObject.transform.position = new Vector3(0, 5, 0);
        caught.enabled = false;
        animator.SetBool("Grounded", true);
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

    private void OnTriggerEnter(Collider other)
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
        yield return new WaitForSeconds(3);
        Scene loadedLevel = SceneManager.GetActiveScene();
        SceneManager.LoadScene(loadedLevel.buildIndex);
    }

    void SetCountText()
    {
        counter.text = count.ToString() + " Inspiration";
        if (count != 1)
        {
            counter.text += "s";
        }
    }
}
