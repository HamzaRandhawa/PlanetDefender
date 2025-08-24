using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionVFX : MonoBehaviour
{
    [SerializeField] private ParticleSystem ps;
    private void Awake()
    {
        // ps = GetComponent<ParticleSystem>();
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    private void OnEnable()
    {
        // Play again when pulled from pool
        ps.Play();
        // Disable after effect duration
        Invoke(nameof(Disable), ps.main.duration);
    }

    private void Disable()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke(); // avoid stacking invokes
    }
}
