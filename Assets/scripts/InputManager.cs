using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
   
    private Car _selectedCar = null;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //Debug.Log(message:"Mouse Clicked");

            CastRay();
        }
         
         if (_selectedCar)
         {
            if(_selectedCar.IsMoving == false)
            {
                if(Input.GetAxis("Vertical") > 0)
                {
                    StartCoroutine(_selectedCar.MoveOneUnitUp());
                }

                if(Input.GetAxis("Vertical") < 0)
                {
                    StartCoroutine(_selectedCar.MoveOneUnitDown());
                }
            }
         }
        
    }

    private void CastRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        
            if (raycastHit.transform.CompareTag("Car"))
            {
                //Debug.Log(message: "Car Clicked");

                _selectedCar = raycastHit.transform.GetComponent<Car>();
                
            }
    }      
}
    

