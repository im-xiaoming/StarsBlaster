using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Shooting SFX")]
    [SerializeField] AudioClip shootingSFX;
    [SerializeField] [Range(0, 1)] float shootingVolume;

    [Header("Enemy Explosion SFX")]
    [SerializeField] AudioClip enemyExplosionSFX;
    [SerializeField] [Range(0, 1)] float enemyExplosionVolume;

    [Header("Player Explosion SFX")]
    [SerializeField] AudioClip playerExplosionSFX;
    [SerializeField] [Range(0, 1)] float playerExplosionVolume;

    static AudioManager instance;


    public void PlayShootingSFX()
    {
        AudioSource.PlayClipAtPoint(shootingSFX, Camera.main.transform.position, shootingVolume);
    }

    public void PlayEnemyExplosionSFX()
    {
        AudioSource.PlayClipAtPoint(enemyExplosionSFX, Camera.main.transform.position, enemyExplosionVolume);
    }

    public void PlayPLayerExplosionSFX()
    {
        AudioSource.PlayClipAtPoint(playerExplosionSFX, Camera.main.transform.position, playerExplosionVolume);
    }

    void Awake()
    {
        // AudioManager[] audioManagers = FindObjectsByType<AudioManager>(FindObjectsSortMode.None);
        // if (audioManagers.Length > 1)
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
