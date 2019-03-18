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
    [SerializeField] private AudioSource swipe;
    [SerializeField] private bool snatch;

    public bool visible = true;

    public int count;
    [SerializeField] private int winCount;
    private int buildNum = 0;

    public Text counter;
    public Text counter1;

    public bool canMove = true;


    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        buildNum = scene.buildIndex;
        //caught.enabled = false;
        animator.SetBool("Grounded", true);
        //checkPoint = transform.position;
    }

    void Update()
    {
        if(canMove) {
            if (count >= winCount)
            {
                WinState();
            }

            float v = Input.GetAxis("Vertical");
            if(v != 0) {
                if(!GetComponent<AudioSource>().isPlaying) {
                    GetComponent<AudioSource>().Play();
                }
            }
            else {
                GetComponent<AudioSource>().Pause();
            }
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
            transform.position += transform.right * h * Time.deltaTime;
            transform.Rotate(0, h * turnSpeed * Time.deltaTime, 0);
            //transform.position
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("comp"))
        {
            visible = false;
            if (snatch == true)
            {
                if(!swipe.isPlaying) {
                    swipe.Play();
                }
                other.gameObject.SetActive(false);
                count += 1;
                SetCountText();
                bulbs.Play();
                visible = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("exit");
        visible |= other.gameObject.CompareTag("comp");
    }

    void SetCountText()
    {
        counter.text = count.ToString() + "/" + winCount.ToString() + " Portfolio Piece";
        if (count != 1)
        {
            counter.text += "s";
        }
        counter1.text = count.ToString() + "/" + winCount.ToString() + " Portfolio Piece";
        if (count != 1)
        {
            counter1.text += "s";
        }
    }

    private void WinState() {
        
        if(buildNum != 3) {
                SceneManager.LoadScene(buildNum + 1);
            }
            else {
                SceneManager.LoadScene(0);
            }
    }
}
