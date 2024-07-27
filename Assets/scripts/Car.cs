using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] public float movementUnit = 2.5f;
    public bool ClickedOn {get; set; }
    [SerializeField] private Rigidbody rigidbody;
    public bool IsMoving{get; set; } = false;
    public IEnumerator MoveOneUnitUp()
    {
        IsMoving = true;

        Vector3 startingPos = transform.position;
        while(Vector3.Distance(startingPos, transform.position) < movementUnit)
        {
            rigidbody.MovePosition(rigidbody.position + transform.forward *(speed * Time.deltaTime));

            yield return null; 
        }
    }

    public IEnumerator MoveOneUnitDown()
    {
        IsMoving = true;

        Vector3 startingPos = transform.position;
        while(Vector3.Distance(startingPos, transform.position) < movementUnit)
        {
            rigidbody.MovePosition(rigidbody.position + -transform.forward *(speed * Time.deltaTime));
            
            yield return null; 
        }
        IsMoving = false;
    }

   
    public IEnumerator MoveOneUnit()
    {
        Vector3 startingPos = transform.position;

        while(Vector3.Distance(startingPos, transform.position) < movementUnit)
        {
            rigidbody.MovePosition(rigidbody.position + transform.forward *(speed * Time.deltaTime));

            yield return null; 
        }
        
    }
}
