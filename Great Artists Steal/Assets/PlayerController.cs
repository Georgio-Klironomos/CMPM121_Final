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

    void Start()
    {
        //gameObject.transform.position = new Vector3(0, 5, 0);

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
        Debug.Log("Collide2");
        if (other.gameObject.CompareTag("comp"))
        {
            Debug.Log("Collide2");
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();
            bulbs.Play();
        }
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
