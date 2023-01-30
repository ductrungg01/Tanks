using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class TankHealth : MonoBehaviour
{
    public float _StartingHealth = ConfigurationUtil.StartingHealth;          
    public Slider _Slider;                        
    public Image _FillImage;                      
    public Color _FullHealthColor = Color.green;  
    public Color _ZeroHealthColor = Color.red;    
    public GameObject _ExplosionPrefab;

    private AudioSource _ExplosionAudio;          
    private ParticleSystem _ExplosionParticles;   
    private float _CurrentHealth;  
    private bool _IsDead;

    private TankInformation _TankInformation;

    private void Awake()
    {
        _ExplosionParticles = Instantiate(_ExplosionPrefab).GetComponent<ParticleSystem>();
        _ExplosionAudio = _ExplosionParticles.GetComponent<AudioSource>();
        _TankInformation = GetComponent<TankInformation>();

        _ExplosionParticles.gameObject.SetActive(false);
    }
    
    private void OnEnable()
    {
        _CurrentHealth = _StartingHealth;

        if (_TankInformation._IsPlayer)
        {
           PlayerStatsManager.Instance.HP = _CurrentHealth;
        }

        _IsDead = false;

        SetHealthUI();
    }

    public void TakeDamage(float amount)
    {
        // Reduce current health by the amount of damage done.
        _CurrentHealth -= amount;

        // Change the UI elements appropriately.
        SetHealthUI ();

        // If the current health is at or below zero and it has not yet been registered, call OnDeath.
        if (_CurrentHealth <= 0f && !_IsDead)
        {
            OnDeath ();
        }
    }

    private void SetHealthUI()
    {
        if (_TankInformation._IsPlayer)
        {
            PlayerStatsManager.Instance.HP = _CurrentHealth;
        }

        // Set the slider's value appropriately.
        _Slider.value = _CurrentHealth;

        // Interpolate the color of the bar between the choosen colours based on the current percentage of the starting health.
        _FillImage.color = Color.Lerp (_ZeroHealthColor, _FullHealthColor, _CurrentHealth / _StartingHealth);
    
    }
    
    private void OnDeath()
    {
        // Set the flag so that this function is only called once.
        _IsDead = true;

        // Play explosion and audio
        PlayExplosionEffect();

        // Turn the tank off.
        gameObject.SetActive (false);
    }

    private void PlayExplosionEffect()
    {
        // Move the instantiated explosion prefab to the tank's position and turn it on.
        _ExplosionParticles.transform.position = transform.position;
        _ExplosionParticles.gameObject.SetActive (true);

        // Play the particle system of the tank exploding.
        _ExplosionParticles.Play ();

        // Play the tank explosion sound effect.
        _ExplosionAudio.Play();
    }
}