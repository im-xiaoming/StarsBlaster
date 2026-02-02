using UnityEngine;

public class Heath : MonoBehaviour
{
    [SerializeField] int heath = 50;
    [SerializeField] ParticleSystem hitParticle;
    DamageDealer damageDealer;
    [SerializeField] bool applyCameraShake;
    CameraShake cameraShake;

    void Start()
    {
        damageDealer = GetComponent<DamageDealer>();
        cameraShake = Camera.main.GetComponent<CameraShake>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            if (heath <= 0)
            {
                damageDealer.Hit();
            }  
        }
        PlayHitParticles();
        if (applyCameraShake)
        {
            cameraShake.Play();
        }
        Destroy(collision.gameObject);
    }

    void TakeDamage(int damage)
    {
        heath -= damage;
        CheckAlive();
    }

    void PlayHitParticles()
    {
        ParticleSystem ps = Instantiate(hitParticle, transform.position, Quaternion.identity);
        ps.Play();
        Destroy(ps, ps.main.duration + ps.main.startLifetime.constantMax);
    }

    void CheckAlive()
    {
        if (heath <= 0)
        {
            Destroy(gameObject);
        }
    }
}
