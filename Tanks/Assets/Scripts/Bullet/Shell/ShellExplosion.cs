using UnityEngine;

public class ShellExplosion : MonoBehaviour
{
    public LayerMask m_TankMask;
    public ParticleSystem m_ExplosionParticles;       
    public AudioSource m_ExplosionAudio;              
    private float m_MaxDamage = 100f;                  
    private float m_ExplosionForce = 1000f;            
    private float m_MaxLifeTime = 2f;                  
    private float m_ExplosionRadius = 5f;              


    private void Start()
    {
        PoolManager.Instance.shellPooler.OnReturnToPool(gameObject, m_MaxLifeTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        // Find all the tanks in an area around the shell and damage them.
        
        m_ExplosionParticles.gameObject.SetActive(true);
        m_ExplosionParticles.gameObject.transform.position = this.transform.position;
        
        Collider[] colliders = Physics.OverlapSphere(transform.position, m_ExplosionRadius, m_TankMask);
        for (int i = 0; i < colliders.Length; i++)
        {
            Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();

            if (!targetRigidbody)
                continue;
            
            targetRigidbody.AddExplosionForce(m_ExplosionForce, transform.position, m_ExplosionRadius);

            TankHealth targetHealth = targetRigidbody.GetComponent<TankHealth>();
            
            if (!targetHealth)
                continue;

            //float damage = CalculateDamage(targetRigidbody.position);
            
            float damage = CalculateDamage.Calculate(
                new ExplosionInfor(this.transform.position, m_ExplosionRadius, m_ExplosionForce),
                targetRigidbody.position,
                m_MaxDamage,
                132
            );

            if (damage != 0)
            {
                targetHealth.TakeDamage(damage);
            }
        }

        m_ExplosionParticles.transform.parent = null;
        
        m_ExplosionParticles.Play();
        
        m_ExplosionAudio.Play();
        
        PoolManager.Instance.shellPooler.OnReturnToPool(m_ExplosionParticles.gameObject, m_ExplosionParticles.duration);
        PoolManager.Instance.shellPooler.OnReturnToPool(gameObject);
    }
}