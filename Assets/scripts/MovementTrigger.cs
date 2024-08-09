using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTrigger : MonoBehaviour
{
    public bool CanMove {get; private set; } = true;

    private void OnTriggerStay(Collider other)
    {
        CanMove = false;
        
    }

    private void OnTriggerExit(Collider other)
    {
        CanMove = true;
    }
}
  