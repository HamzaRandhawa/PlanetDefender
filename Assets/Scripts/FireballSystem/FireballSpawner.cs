using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSpawner : MonoBehaviour
{
    [SerializeField] private Transform earth;
    [SerializeField] private float spawnRadius = 20f;
    [SerializeField] private float spawnInterval = 2f;

    private void OnEnable()
    {
        RoundTimer.OnRoundEnd += StopSpawning;
        GameManager.OnPlanetDestroyed += StopSpawning;
    }

    private void OnDisable()
    {
        RoundTimer.OnRoundEnd -= StopSpawning;
        GameManager.OnPlanetDestroyed -= StopSpawning;

    }
    private void Start()
    {
        InvokeRepeating(nameof(SpawnFireball), 1f, spawnInterval);
    }

    private void SpawnFireball()
    {
        // Pick a random point on unit circle (in XY plane)
        Vector2 randomCircle = Random.insideUnitCircle.normalized;  

        // Scale it to spawn radius
        Vector3 spawnPos = new Vector3(
            randomCircle.x * spawnRadius,
            randomCircle.y * spawnRadius,
            earth.position.z // same Z as Earth
        );

        GameObject ball;
        if(Random.value > 0.3f)
            ball = ObjectPooler.Instance.SpawnFromPool("Fireball", spawnPos, Quaternion.identity);
        else
            ball = ObjectPooler.Instance.SpawnFromPool("Iceball", spawnPos, Quaternion.identity);  

        // Make fireball fall toward Earth
        Ball fb = ball.GetComponent<Ball>();
        fb.SetTarget(earth.position);
    }
    private void StopSpawning()
    {
        CancelInvoke(nameof(SpawnFireball));
    }
}
