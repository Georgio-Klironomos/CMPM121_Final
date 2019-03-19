using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private SecuritySystem levelOne;
    [SerializeField] private GameObject thought1;
    [SerializeField] private GameObject thought2;
    [SerializeField] private GameObject thought3;
    
    
    // Start is called before the first frame update
    void Start()
    {
        thought1.SetActive(true);
        thought2.SetActive(false);
        thought3.SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(levelOne.loseCount > 1) {
            thought1.SetActive(false);
            thought2.SetActive(true);
            thought3.SetActive(false);
        }
    }
}
