using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Text scoreText; // 점수를 출력할 UI 텍스트
    public Text bestScoreText;// 베스트 스코어를 출력할 UI 텍스트
    public Slider scoreSlider;
    public float maxHp = 60;
    public float curHp = 60;
    public GameObject retryButton;
    public GameObject menuButton;

    public bool isGameover = false;

    private int score = 0;
    private int bestScore = 0;
    void Start()
    {
        Instance = this; // 인스턴스 할당
        scoreSlider.value = maxHp;

        // 베스트 스코어 불러오기
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
    }
    public void AddScore(int newScore)
    {
        if (!isGameover)
        {
            score += newScore;
            scoreText.text = "$: " + score;
        }
    }

    public void Timer()
    {
        if (curHp >= 0)
        {
            curHp -= Time.deltaTime;
            scoreSlider.value = (int)curHp;
        }
        else
        {
            EndGame();
        }
    }
    private void EndGame()
    {
        isGameover = true;
        retryButton.SetActive(true); // 게임 종료 시 리트라이 버튼 활성화
        menuButton.SetActive(true);

        // 현재 점수가 베스트 스코어보다 높으면 갱신
        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("BestScore", bestScore);
        }

        // 베스트 스코어 출력
        bestScoreText.text = "Best Score: " + bestScore;
        bestScoreText.gameObject.SetActive(true);
    }
    void Update()
    {
        if (!isGameover)
        {
            Timer();
        }
    }
}
