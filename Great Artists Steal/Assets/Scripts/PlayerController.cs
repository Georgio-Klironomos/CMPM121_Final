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
    [SerializeField] private bool snatch;

    public bool visible = true;

    public int count;
    [SerializeField] private int winCount;

    public Text counter;


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
        if(Input.GetAxis("Jump") > 0)
        {
            snatch = true;
        }
        else
        {
            snatch = false;
        }

        animator.SetFloat("MoveSpeed", v);

        transform.position += transform.forward * v * moveSpeed * Time.deltaTime;
        transform.Rotate(0, h * turnSpeed * Time.deltaTime, 0);

    }

    void OnCollisionStay(Collision other)
    {
        Debug.Log("enter");
        if (other.gameObject.CompareTag("comp") && snatch == true)
        {
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();
            bulbs.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("comp"))
        {
            visible = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("comp"))
        {
            visible = true;
        }
    }

    void SetCountText()
    {
        counter.text = count.ToString() + " Portfolio Piece";
        if (count != 1)
        {
            counter.text += "s";
        }
    }
}
