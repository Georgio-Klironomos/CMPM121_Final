using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OuchScript : MonoBehaviour
{

    [SerializeField] private GameObject Ouch;
    // Start is called before the first frame update
    void Start()
    {
        Ouch.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private void OnTriggerEnter(Collider other) {
         if(other.gameObject.CompareTag("Player")) {
            Ouch.SetActive(true);
         }
     }
}
