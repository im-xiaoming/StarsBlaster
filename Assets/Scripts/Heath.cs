using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Heath : MonoBehaviour
{
    [SerializeField] int heath = 50;
    [SerializeField] ParticleSystem hitParticle;
    DamageDealer damageDealer;
    [SerializeField] bool applyCameraShake;
    CameraShake cameraShake;
    AudioManager audioManager;
    ScoreKeeper scoreKeeper;
    UIUpdater uIUpdater;
    LevelMananger levelMananger;

    void Start()
    {
        damageDealer = GetComponent<DamageDealer>();
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioManager = FindFirstObjectByType<AudioManager>();
        scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
        uIUpdater = FindFirstObjectByType<UIUpdater>();
        levelMananger = FindFirstObjectByType<LevelMananger>();
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
            if (gameObject.CompareTag("Player"))
            {
                audioManager.PlayPLayerExplosionSFX();
                uIUpdater.DestroyHealth();
            }
        }

        PlayHitParticles();
        if (applyCameraShake)
        {
            cameraShake.Play();
        }
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
            if (gameObject.CompareTag("Player"))
            {
                levelMananger.LoadEndGame();
            }
            else
            {
                audioManager.PlayEnemyExplosionSFX();
                scoreKeeper.UpdateScore(); 
            }
            Destroy(gameObject);
        }
    }
}
