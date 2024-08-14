using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Collision detected with: " + collision.tag);

        if (collision.tag == "Car")
        {
        Debug.Log("Loading next scene...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
