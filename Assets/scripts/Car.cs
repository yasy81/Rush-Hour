using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    public bool ClickedOn {get; set; }

    [SerializeField] private Rigidbody rigidbody;

    private void Update()
    {
        if(ClickedOn)
        {
            rigidbody.MovePosition(rigidbody.position + transform.forward *(speed * Time.deltaTime));
        }
        
    }
}
