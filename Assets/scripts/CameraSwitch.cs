using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject cam1; 
    public GameObject cam2;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("key1"))
        {
            cam1.SetActive(true);
            cam1.SetActive(false);
        }

        if(Input.GetButtonDown("key2"))
        {
            cam1.SetActive(false);
            cam1.SetActive(true);
        }
    }
}
