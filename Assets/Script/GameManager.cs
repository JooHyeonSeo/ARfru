using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Text scoreText; // ������ ����� UI �ؽ�Ʈ
    public Text bestScoreText;// ����Ʈ ���ھ ����� UI �ؽ�Ʈ
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
        Instance = this; // �ν��Ͻ� �Ҵ�
        scoreSlider.value = maxHp;

        // ����Ʈ ���ھ� �ҷ�����
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
        retryButton.SetActive(true); // ���� ���� �� ��Ʈ���� ��ư Ȱ��ȭ
        menuButton.SetActive(true);

        // ���� ������ ����Ʈ ���ھ�� ������ ����
        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("BestScore", bestScore);
        }

        // ����Ʈ ���ھ� ���
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
