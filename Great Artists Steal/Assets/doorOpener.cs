using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorOpener : MonoBehaviour
{
    [SerializeField] Animator opener;
    [SerializeField] PlayerController player;
    [SerializeField] int openCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.count >= openCount)
        {
            opener.SetTrigger("Open");
            Debug.Log("opener?");
        }
    }
}
