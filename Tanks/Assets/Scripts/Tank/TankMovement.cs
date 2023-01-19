using UnityEngine;
using UnityEngine.Serialization;

public class TankMovement : MonoBehaviour
{
    public float _Speed = 12f;            
    public float _TurnSpeed = 180f;       
    public AudioSource _MovementAudio;    
    public AudioClip _EngineIdling;       
    public AudioClip _EngineDriving;      
    public float _PitchRange = 0.2f;
    
    private string _MovementAxisName;     
    private string _TurnAxisName;         
    private Rigidbody _Rigidbody;         
    private float _MovementInputValue;    
    private float _TurnInputValue;        
    private float _OriginalPitch;

    private TankInformation _TankInformation;

    private void Awake()
    {
        _Rigidbody = GetComponent<Rigidbody>();
        _TankInformation = GetComponent<TankInformation>();
    }


    private void OnEnable ()
    {
        _Rigidbody.isKinematic = false;
        _MovementInputValue = 0f;
        _TurnInputValue = 0f;
    }


    private void OnDisable ()
    {
        _Rigidbody.isKinematic = true;
    }


    private void Start()
    {
        _MovementAxisName = "Vertical" + "Player";
        _TurnAxisName = "Horizontal" + "Player";

        _OriginalPitch = _MovementAudio.pitch;
    }
    

    private void Update()
    {
        if (_TankInformation._IsPlayer)
        {
            // Store the player's input and make sure the audio for the engine is playing.
            _MovementInputValue = Input.GetAxis(_MovementAxisName);
            _TurnInputValue = Input.GetAxis(_TurnAxisName);
        }

        EngineAudio();
    }


    private void EngineAudio()
    {
        // We need detect the input for player but don't need for enemy
        if (_TankInformation._IsPlayer)
        {
            // If there is no input (the tank is stationary)...
            if (Mathf.Abs(_MovementInputValue) < 0.1f && Mathf.Abs(_TurnInputValue) < 0.1f)
            {
                // ... and if the audio source is currently playing the driving clip...
                if (_MovementAudio.clip == _EngineDriving)
                {
                    IdleAudioEngine();
                }
            }
            else
            {
                // Otherwise if the tank is moving and if the idling clip is currently playing...
                if (_MovementAudio.clip == _EngineIdling)
                {
                    DrivingAudioEngine();
                }
            }
        }
        else
        {
            DrivingAudioEngine();
        }
    }

    private void DrivingAudioEngine()
    {
        // ... change the clip to driving and play.
        _MovementAudio.clip = _EngineDriving;
        _MovementAudio.pitch = Random.Range(_OriginalPitch - _PitchRange, _OriginalPitch + _PitchRange);
        _MovementAudio.Play();
    }

    private void IdleAudioEngine()
    {
        // ... change the clip to idling and play it.
        _MovementAudio.clip = _EngineIdling;
        _MovementAudio.pitch = Random.Range (_OriginalPitch - _PitchRange, _OriginalPitch + _PitchRange);
        _MovementAudio.Play();
    }


    private void FixedUpdate()
    {
        if (_TankInformation._IsPlayer)
        {
            // Adjust the rigidbodies position and orientation in FixedUpdate.
            Move();
            Turn();
        }
    }


    private void Move()
    {
        // Adjust the position of the tank based on the player's input.
        // Create a vector in the direction the tank is facing with a magnitude based on the input, speed and the time between frames.
        Vector3 movement = transform.forward * _MovementInputValue * _Speed * Time.deltaTime;

        // Apply this movement to the rigidbody's position.
        _Rigidbody.MovePosition(_Rigidbody.position + movement);
    }


    private void Turn()
    {
        // Determine the number of degrees to be turned based on the input, speed and time between frames.
        float turn = _TurnInputValue * _TurnSpeed * Time.deltaTime;

        // Make this into a rotation in the y axis.
        Quaternion turnRotation = Quaternion.Euler (0f, turn, 0f);

        // Apply this rotation to the rigidbody's rotation.
        _Rigidbody.MoveRotation (_Rigidbody.rotation * turnRotation);
    }
}