using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Car : MonoBehaviour
{

    public WheelColliders colliders;

    public WheelMeshes wheelMeshes;
    [SerializeField] private float speed = 10f;
    [SerializeField] public float movementUnit = 3f;

    [SerializeField] private MovementTrigger frontTrigger;
    [SerializeField] private MovementTrigger backTrigger;
    public bool ClickedOn {get; set; }
    [SerializeField] private Rigidbody rigidbody;
    public bool IsMoving{get; set; } = false;
    

    private AudioSource engineAudioSource;
    [SerializeField] private Slider volumeSlider;
   
    private void Awake()
    {
        engineAudioSource = GetComponent<AudioSource>(); 

        if (PlayerPrefs.HasKey("EngineVolume"))
        {
            engineAudioSource.volume = PlayerPrefs.GetFloat("EngineVolume");
        }

        volumeSlider.onValueChanged.AddListener(SetEngineVolume);
    }
    
    private void SetEngineVolume(float volume)
    {
        if (PlayerPrefs.HasKey("EngineVolume"))
        {
            engineAudioSource.volume = PlayerPrefs.GetFloat("EngineVolume");
        }
    }

    private void Update()
    {
        HandleEngineAudioSource();
        ApplyWheelPositions();
        /*MoveOneUnitDown();
        MoveOneUnitUp();*/
    }

    private void HandleEngineAudioSource()
    {
        
        // Check if the car can move and is currently moving
        if (IsMoving && (frontTrigger.CanMove || backTrigger.CanMove) && !engineAudioSource.isPlaying)
        {
            engineAudioSource.Play(); // Start playing the engine sound
        }
        else if ((!IsMoving || (!frontTrigger.CanMove && !backTrigger.CanMove)) && engineAudioSource.isPlaying)
        {
            engineAudioSource.Stop(); // Stop playing the engine sound
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
    
    
    

    void ApplyWheelPositions()
    {
        UpdateWheel(colliders.FRWheel,wheelMeshes.FRWheel);
        UpdateWheel(colliders.FLWheel,wheelMeshes.FLWheel);
        UpdateWheel(colliders.RRWheel,wheelMeshes.RRWheel);
        UpdateWheel(colliders.RLWheel,wheelMeshes.RLWheel);
    }

    void UpdateWheel(WheelCollider coll, MeshRenderer wheelMesh)
    {
        Vector3 position;
        Quaternion rotation;
        coll.GetWorldPose(out position, out rotation);
    
        // Update wheel mesh position and rotation
        wheelMesh.transform.position = position;
        wheelMesh.transform.rotation = rotation;

        float motorTorque = 0f; // Default to no torque

        // Apply torque based on movement triggers
        if (IsMoving)
        {
            if (frontTrigger.CanMove)
            {
                motorTorque = 10; // Forward movement
            }
            else if (backTrigger.CanMove)
            {
                motorTorque = -10; // Backward movement
            }
            else if (IsMoving == false)
            {
            motorTorque = 0;
            }
        }
        
        

        coll.motorTorque = motorTorque;
        
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
    } 

}
