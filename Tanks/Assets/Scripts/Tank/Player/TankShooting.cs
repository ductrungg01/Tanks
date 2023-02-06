using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class TankShooting : MonoBehaviour
{
    #region Fields
    public Transform _FireTransform;    
    public Slider _AimSlider;           
    public AudioSource _ShootingAudio;  
    public AudioClip _ChargingClip;     
    public AudioClip _FireClip;         
    public float _MinLaunchForce = 15f; 
    public float _MaxLaunchForce = 30f; 
    public float _MaxChargeTime = 0.75f;
    
    private string _FireButton = "FirePlayer";         
    private float _CurrentLaunchForce;  
    private float _ChargeSpeed;         
    private bool _Fired;

    private TankInformation _TankInformation;

    public ShootingType typeInUse;
    private ShootingCommander _ShootingCommander;

    private Timer _TimerForMachineGun;
    #endregion
    
    private void OnEnable()
    {
        _CurrentLaunchForce = _MinLaunchForce;
        _AimSlider.value = _MinLaunchForce;
    }
    
    private void Start()
    {
        _TankInformation = GetComponent<TankInformation>();

        _ChargeSpeed = (_MaxLaunchForce - _MinLaunchForce) / _MaxChargeTime;

        _ShootingCommander = gameObject.AddComponent<ShootingCommander>();
        _ShootingCommander.AddMethod(new RocketShooting());
        _ShootingCommander.AddMethod(new MachineGunShooting());
        _ShootingCommander.AddMethod(new SmokeGrenadeShooting());
        _ShootingCommander.AddMethod(new SuperArroundShooting());

        _TimerForMachineGun = gameObject.AddComponent<Timer>();
        _TimerForMachineGun.Duration = 0.03f;
        _TimerForMachineGun.Run();
    }

    private void Update()
    {
        if (_TankInformation._IsPlayer)
        {
            switch (typeInUse)
            {
                case ShootingType.Rocket:
                {
                    _AimSlider.value = _MinLaunchForce;

                    if (_CurrentLaunchForce >= _MaxLaunchForce && !_Fired)
                    {
                        _CurrentLaunchForce = _MaxLaunchForce;
                        _Fired = true;
                        Fire();
                    }
                    else if (Input.GetButtonDown(_FireButton))
                    {
                        _Fired = false;
                        _CurrentLaunchForce = _MinLaunchForce;

                        _ShootingAudio.clip = _ChargingClip;
                        _ShootingAudio.Play();
                    }
                    else if (Input.GetButton(_FireButton) && !_Fired)
                    {
                        _CurrentLaunchForce += _ChargeSpeed * Time.deltaTime;

                        _AimSlider.value = _CurrentLaunchForce;
                    }
                    else if (Input.GetButtonUp(_FireButton) && !_Fired)
                    {
                        _Fired = true;
                        Fire();
                    }
                    
                    break;
                }
                case ShootingType.MachineGun:
                {
                    if (Input.GetButton(_FireButton) && _TimerForMachineGun.Finished)
                    {
                        _TimerForMachineGun.Stop();
                        Fire();
                        _TimerForMachineGun.Run();
                    }
                    break;
                }
                case ShootingType.SmokeGrenade:
                {
                    if (Input.GetButton(_FireButton))
                    {
                        Fire();
                    }

                    break;
                }
                case ShootingType.SuperArround:
                {
                    if (Input.GetButton(_FireButton))
                    {
                        _ShootingCommander.Fire(typeInUse,this.transform.position, _FireTransform.rotation, _FireTransform.forward);
                    }
                    break;
                }
            }
        }
    }
    
    private void Fire()
    {
        _ShootingCommander.Fire(typeInUse,_FireTransform.position, _FireTransform.rotation, _CurrentLaunchForce * _FireTransform.forward);
    }
}