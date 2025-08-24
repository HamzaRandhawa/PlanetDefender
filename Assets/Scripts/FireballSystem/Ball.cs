using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ball : MonoBehaviour
{
    protected Vector3 target;
    [SerializeField] protected float speed = 5f;
    [SerializeField] protected int damage = 10;
    [SerializeField] protected int destroyReward = 10;
    
    void Start()
    {
        
    }

    public virtual void SetTarget(Vector3 targetPosition)
    {
        target = targetPosition;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
    
    public virtual void OnCollisionEnter(Collision collision)
    {
        // Debug.Log("Some collision Occured!");

        if (collision.gameObject.CompareTag("Earth"))
        {
            OnHitEarth();
        }
        else if (collision.gameObject.CompareTag("Snake"))
        {
            if(collision.gameObject.GetComponent<SnakeBodyTrack>().IsSurrounded())
                OnSnakeHit();
        }
    }

    protected virtual void OnHitEarth()
    {
        // PlayImpactVFX();
        // // Debug.Log("Earth hit Collision!");
        // // Notify listeners
        // GameManager.EarthHit(damage);
        // // Disable fireball (return to pool)
        // gameObject.SetActive(false);
    }

    protected virtual void OnSnakeHit()
    {
        // ScoreManager.Instance.AddScore(destroyReward);
        // gameObject.SetActive(false);
    }
    
    protected void PlayImpactVFX()
    {
        ObjectPooler.Instance.SpawnFromPool(
            "ExplosionVFX",
            transform.position,
            Quaternion.identity
        );
        // Fireball fb = fireball.GetComponent<Fireball>();
    }
    protected void PlayExplosionSound()
    {
        // Play Explosion SFX
        GameObject sfx = ObjectPooler.Instance.SpawnFromPool("ExplosionSFX", transform.position, Quaternion.identity);
        var audioSource = sfx.GetComponent<AudioSource>();
        audioSource.Play();
    }
    
    protected void PlayInceptionSound()
    {
        GameObject sfx = ObjectPooler.Instance.SpawnFromPool("InceptorSound", transform.position, Quaternion.identity);
        var audioSource = sfx.GetComponent<AudioSource>();
        audioSource.Play();
    }
    
}
