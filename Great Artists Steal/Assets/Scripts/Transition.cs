using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    [SerializeField] private PlayerController student;
    void Start() {
        student.canMove = false;
        StartCoroutine(LevelStart());
    }

    IEnumerator LevelStart() {
        Debug.Log("trans");
         yield return new WaitForSeconds(5);
         student.canMove = true;
         Destroy(gameObject);
    }
}
