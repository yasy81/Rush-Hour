using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject cam1; 
    public GameObject cam2;
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            cam1.SetActive(true);
            cam2.SetActive(false);
            cam1.tag = "MainCamera";
            cam2.tag = "Untagged";
        } 

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            cam1.SetActive(false);
            cam2.SetActive(true);
            cam1.tag = "Untagged";
            cam2.tag = "MainCamera";
        }
    }

   
}
