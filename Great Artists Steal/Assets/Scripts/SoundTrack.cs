using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SoundTrack : MonoBehaviour
{
    private AudioSource audioSource;
    private int buildNum = 0;
    
    void Update() {
        Scene scene = SceneManager.GetActiveScene();
        buildNum = scene.buildIndex;
        if(buildNum > 3 ) {
            Destroy(this.gameObject);
        }
        else if(buildNum == 3) {
            audioSource.pitch = 1.5f;
        }
        else {
            audioSource.pitch = 1f;
        }
    }
     private void Awake()
     {
            DontDestroyOnLoad(transform.gameObject);
        
         audioSource = GetComponent<AudioSource>();
     }
}
