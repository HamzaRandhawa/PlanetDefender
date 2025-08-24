using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledAudio : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    private void Awake()
    {
        // audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        // Auto-disable after clip length
        Invoke(nameof(Disable), audioSource.clip.length);
    }

    private void Disable()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
