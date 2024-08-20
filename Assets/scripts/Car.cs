using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] public float movementUnit = 3f;

    [SerializeField] private MovementTrigger frontTrigger;
    [SerializeField] private MovementTrigger backTrigger;
    public bool ClickedOn {get; set; }
    [SerializeField] private Rigidbody rigidbody;
    public bool IsMoving{get; set; } = false;
    public IEnumerator MoveOneUnitUp()
    {
        if (frontTrigger.CanMove == false) 
        {
            Debug.Log("Can Not Move up");
            yield break;
        }

        IsMoving = true;

        Vector3 startingPos = transform.position;
        while(Vector3.Distance(startingPos, transform.position) < movementUnit)
        {
            rigidbody.MovePosition(rigidbody.position + transform.forward *(speed * Time.deltaTime));

            yield return null; 
        }
        IsMoving = false;
    }

    public IEnumerator MoveOneUnitDown()
    {
        if (backTrigger.CanMove == false)
        {
            Debug.Log("Can Not Move Down");
            yield break;
        }
        IsMoving = true;

        Vector3 startingPos = transform.position;
        while(Vector3.Distance(startingPos, transform.position) < movementUnit)
        {
            rigidbody.MovePosition(rigidbody.position + -transform.forward *(speed * Time.deltaTime));
            
            yield return null; 
        }
        IsMoving = false;
    }

}
