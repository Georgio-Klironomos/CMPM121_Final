using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        backToStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator backToStart()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);
    }
}
