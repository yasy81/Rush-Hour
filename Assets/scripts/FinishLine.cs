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
            UnlockNewLevel();
            ButterflyConfetti.SetActive(true); 
            ButterflyConfetti1.SetActive(true);
            StartCoroutine(WaitAndLoadNextScene()); 
        }
    }

    private IEnumerator WaitAndLoadNextScene()
    {
        
        while (!ButterflyConfetti.activeInHierarchy)
        {
            yield return null; 
        }

        
        yield return new WaitForSeconds(3f);

        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    
    void UnlockNewLevel()
    {
        if(SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex+1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel" , 1)+ 1);
            PlayerPrefs.Save();
        }
    }

    
}
