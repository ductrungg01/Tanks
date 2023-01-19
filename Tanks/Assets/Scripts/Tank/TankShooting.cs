using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class TankShooting : MonoBehaviour
{
    public Transform _FireTransform;    
    public Slider _AimSlider;           
    public AudioSource _ShootingAudio;  
    public AudioClip _ChargingClip;     
    public AudioClip _FireClip;         
    public float _MinLaunchForce = 15f; 
    public float _MaxLaunchForce = 30f; 
    public float _MaxChargeTime = 0.75f;
    
    private string _FireButton;         
    private float _CurrentLaunchForce;  
    private float _ChargeSpeed;         
    private bool _Fired;

    private TankInformation _TankInformation;


    private void OnEnable()
    {
        _CurrentLaunchForce = _MinLaunchForce;
        _AimSlider.value = _MinLaunchForce;
    }


    private void Start()
    {
        _FireButton = "Fire" + "Player";

        _TankInformation = GetComponent<TankInformation>();

        _ChargeSpeed = (_MaxLaunchForce - _MinLaunchForce) / _MaxChargeTime;
    }

    private void Update()
    {
        if (_TankInformation._IsPlayer)
        {
            // Track the current state of the fire button and make decisions based on the current launch force.
            _AimSlider.value = _MinLaunchForce;
            
            if (_CurrentLaunchForce >= _MaxLaunchForce && !_Fired)
            {
                // at max charge and not yet fire
                _CurrentLaunchForce = _MaxLaunchForce;
                Fire();
            }
            else if (Input.GetButtonDown(_FireButton))
            {
                // have we pressed fire for the first time?
                _Fired = false;
                _CurrentLaunchForce = _MinLaunchForce;

                _ShootingAudio.clip = _ChargingClip;
                _ShootingAudio.Play();
            }
            else if (Input.GetButton(_FireButton) && !_Fired)
            {
                // holding the fire button and not yet fired
                _CurrentLaunchForce += _ChargeSpeed * Time.deltaTime;

                _AimSlider.value = _CurrentLaunchForce;
            }
            else if (Input.GetButtonUp(_FireButton) && !_Fired)
            {
                // we released the button and having not fired yet
                Fire();
            }
        }
    }


    private void Fire()
    {
        // Instantiate and launch the shell.
        _Fired = true;
        
        GameObject shell = PoolManager.Instance.shellPooler.OnTakeFromPool(_FireTransform.position, _FireTransform.rotation);
        
        if (shell)
        {
            Rigidbody shellInstance = shell.GetComponent<Rigidbody>();
        
            shellInstance.velocity = _CurrentLaunchForce * _FireTransform.forward;

            _ShootingAudio.clip = _FireClip;
            _ShootingAudio.Play();

            _CurrentLaunchForce = _MinLaunchForce;
        }
        else
        {
            Debug.Log("Cannot fire!");
        }
        
    }
}