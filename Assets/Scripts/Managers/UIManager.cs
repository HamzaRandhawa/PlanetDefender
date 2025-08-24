using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private TMP_Text timerText;
    
    [SerializeField] private TMP_Text winText;
    [SerializeField] private TMP_Text looseText;
    void Start()
    {
        
    }
    private void OnEnable()
    {
        Earth.OnHealthChanged += UpdateHealth;
        ScoreManager.OnScoreChanged += UpdateScore;
        RoundTimer.OnTimeChanged += UpdateTime;
        RoundTimer.OnRoundEnd += ShowWinText;
        GameManager.OnPlanetDestroyed += ShowLooseText;

    }

    private void OnDisable()
    {
        Earth.OnHealthChanged -= UpdateHealth;
        ScoreManager.OnScoreChanged -= UpdateScore;
        RoundTimer.OnTimeChanged -= UpdateTime;
        RoundTimer.OnRoundEnd -= ShowWinText;
        GameManager.OnPlanetDestroyed -= ShowLooseText;


    }

    public void UpdateHealth(int health)
    {
        healthText.text = $"{health}";
    }

    public void UpdateScore(int score)
    {
        scoreText.text = $"Score: {score}";
    }
    public void UpdateTime(float time)
    {
        timerText.text = $"{time}";
    }
    public void ShowWinText()
    {
        winText.gameObject.SetActive(true);
    }
    public void ShowLooseText()
    {
        looseText.gameObject.SetActive(true);
    }
   

    void Update()
    {
        
    }
}
