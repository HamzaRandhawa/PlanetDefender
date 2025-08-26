using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Earth : MonoBehaviour
{
    public int MaxHealth;
    public int CurrentHealth { get; private set; }
    
    public HealthBar healthBar;

    public static event Action<int> OnHealthChanged; 
    
    [SerializeField] private float shakeMagnitude = 0.2f;
    [SerializeField] private float shakeDuration = 0.3f;

    private void Awake()
    {
        CurrentHealth = MaxHealth;
        healthBar.SetMaxHealth(MaxHealth);
    }
    private void OnEnable()
    {
        GameManager.OnEarthHit += TakeDamage;
    }

    private void OnDisable()
    {
        GameManager.OnEarthHit -= TakeDamage;
    }

    private void TakeDamage(int damage)
    {
        if (!RoundTimer.IsRunning()) return;
        
        CurrentHealth = Mathf.Max(0, CurrentHealth - damage);
        healthBar.SetHealth(CurrentHealth);
        OnHealthChanged?.Invoke(CurrentHealth);
        
        // Start shaking coroutine
        StartCoroutine(Shake(shakeDuration, shakeMagnitude));
        
        if (CurrentHealth <= 0)
        {
            Debug.Log("💥 Earth Destroyed!");
            GameManager.DestroyPlanet();
            RoundTimer.StopTimer();
            // TODO: trigger GameOver
        }
        Debug.Log("Earth took damage! Current HP: " + CurrentHealth);
    }

    private System.Collections.IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPos = transform.localPosition;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = originalPos + new Vector3(x, y, 0f);

            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = originalPos;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
