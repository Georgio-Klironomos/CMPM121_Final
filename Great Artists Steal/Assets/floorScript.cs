using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorScript : MonoBehaviour
{
    public GameObject mf;
    // Start is called before the first frame update
    void Start()
    {
        mf.GetComponent<Renderer>().material.color = Color.grey;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
