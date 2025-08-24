using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iceball : Ball
{
    void Start()
    {
        
    }
    protected override void OnHitEarth()
    {
        PlayImpactVFX();
        PlayExplosionSound();
        // Debug.Log("Earth hit Collision!");
        // Notify listeners
        GameManager.EarthHit(damage);

        // Disable fireball (return to pool)
        gameObject.SetActive(false);
    }

    protected override void OnSnakeHit()
    {
        PlayInceptionSound();
        ScoreManager.Instance.AddScore(destroyReward);
        gameObject.SetActive(false);
    }
    protected void PlayImpactVFX()
    {
        ObjectPooler.Instance.SpawnFromPool(
            "IceExplosion",
            transform.position,
            Quaternion.identity
        );
        // Fireball fb = fireball.GetComponent<Fireball>();
    }
}
