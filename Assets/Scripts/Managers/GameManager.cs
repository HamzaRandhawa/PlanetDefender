using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event Action<int> OnEarthHit;
    public static void EarthHit(int damage) => OnEarthHit?.Invoke(damage);
    [SerializeField] private Earth earth;

    public static event Action OnPlanetDestroyed;
    public static void DestroyPlanet() => OnPlanetDestroyed?.Invoke();

    [SerializeField] private UIManager uiManager;
    // Start is called before the first frame update

    private void Awake()
    {
        // earth = GameObject.FindWithTag("Earth").GetComponent<Earth>();
        // uiManager = GameObject.findw GetComponent<UIManager>();
    }

    private void OnEnable()
    {
        RoundTimer.OnRoundEnd += RoundEnd;
        // OnPlanetDestroyed += PlanetDestroyed;

    }

    private void OnDisable()
    {
        RoundTimer.OnRoundEnd -= RoundEnd;
        // OnPlanetDestroyed -= PlanetDestroyed;

    }

    void Start()
    {
        uiManager.UpdateHealth(earth.MaxHealth);
    }

    void Update()
    {
        
    }

    public static void PlanetDestroyed()
    {
        // RoundTimer.StopRound();
        RoundTimer.StopTimer();
        Debug.Log("Planet destroyed!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        //RoundEnd();
    }

    static void RoundEnd()
    {
        Debug.Log("⏱ Round finished!");

        // Stop game
        //Time.timeScale = 0f;
    }
}
