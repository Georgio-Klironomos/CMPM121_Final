using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SoundTrack : MonoBehaviour
{
    private AudioSource _audioSource;
    private int buildNum = 0;
    

    void Update() {
        Scene scene = SceneManager.GetActiveScene();
        buildNum = scene.buildIndex;
        if(buildNum == 4) {
            Destroy(this.gameObject);
        }
    }
     private void Awake()
     {
            DontDestroyOnLoad(transform.gameObject);
        
         _audioSource = GetComponent<AudioSource>();
     }
 
     public void PlayMusic()
     {
         if (_audioSource.isPlaying) return;
         _audioSource.Play();
     }
 
     public void StopMusic()
     {
         _audioSource.Stop();
     }
}
