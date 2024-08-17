using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    public GameObject ButterflyConfetti;
    public GameObject ButterflyConfetti1;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Car")
        {
            //UnlockedNewLevel();
            ButterflyConfetti.SetActive(true); 
            ButterflyConfetti1.SetActive(true);// Activate the ButterflyConfetti
            StartCoroutine(WaitAndLoadNextScene()); // Start the coroutine to wait and then load the next scene
        }
    }

    private IEnumerator WaitAndLoadNextScene()
    {
        // Wait until ButterflyConfetti is active
        while (!ButterflyConfetti.activeInHierarchy)
        {
            yield return null; // Wait for the next frame
        }

        // Wait for an additional 3 seconds
        yield return new WaitForSeconds(3f);

        // Load the next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /*
    void UnlockNewLevel()
    {
        if(SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActive().buildIndex+1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel" , 1));
            PlayerPrefs.Save();
        }
    }*/
}
