using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{

   // public WheelColliders colliders;

   // public WheelMeshes wheelMeshes;
    [SerializeField] private float speed = 10f;
    [SerializeField] public float movementUnit = 3f;

    [SerializeField] private MovementTrigger frontTrigger;
    [SerializeField] private MovementTrigger backTrigger;
    public bool ClickedOn {get; set; }
    [SerializeField] private Rigidbody rigidbody;
    public bool IsMoving{get; set; } = false;

    private AudioSource engineSound;

    private void Awake()
    {
        engineSound = GetComponent<AudioSource>(); // Get the AudioSource component
    }

    private void Update()
    {
        HandleEngineSound();
        //ApplyWheelPositions();
        /*MoveOneUnitDown();
        MoveOneUnitUp();*/
    }

    private void HandleEngineSound()
    {
        // Check if the car can move and is currently moving
        if (IsMoving && (frontTrigger.CanMove || backTrigger.CanMove) && !engineSound.isPlaying)
        {
            engineSound.Play(); // Start playing the engine sound
        }
        else if ((!IsMoving || (!frontTrigger.CanMove && !backTrigger.CanMove)) && engineSound.isPlaying)
        {
            engineSound.Stop(); // Stop playing the engine sound
        }
    }
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

    /*

    void ApplyWheelPositions()
    {
        UpdateWheel(colliders.FRWheel,wheelMeshes.FRWheel);
        UpdateWheel(colliders.FLWheel,wheelMeshes.FLWheel);
        UpdateWheel(colliders.RRWheel,wheelMeshes.RRWheel);
        UpdateWheel(colliders.RLWheel,wheelMeshes.RLWheel);
    }

    void UpdateWheel(WheelCollider coll, MeshRenderer wheelMesh)
    {
        Quaternion quat;
        Vector3 position;
        coll.GetWorldPose(out position, out quat);
        wheelMesh.transform.position = position;
        wheelMesh.transform.rotation = quat;
    }

    [System.Serializable]
    public class WheelColliders
    {
        public WheelCollider FRWheel;
        public WheelCollider FLWheel;
        public WheelCollider RRWheel;
        public WheelCollider RLWheel;
    }

    [System.Serializable]
    public class WheelMeshes
    {
        public MeshRenderer FRWheel;
        public MeshRenderer FLWheel;
        public MeshRenderer RRWheel;
        public MeshRenderer RLWheel;
    } */

}
