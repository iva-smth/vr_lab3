using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    Transform BallSpawnPosition;
    Transform PinsSpawnPosition;

    [SerializeField] GameObject BallPref;
    [SerializeField] GameObject PinsPref;

    GameObject pins;
    static int GameScore = 0;
    int Frame = 0;
    bool isStrike = false;

    [SerializeField] public static int scoredPins = 0;
    [SerializeField] TMP_Text ScoreText;
    [SerializeField] TMP_Text FrameText;
    [SerializeField] TMP_Text ThrowText;
    [SerializeField] TMP_Text StrikeText;
    [SerializeField] TMP_Text TotalScoreText;
    [SerializeField] GameObject Panel;

    // Start is called before the first frame update
    void Start()
    {
        BallSpawnPosition = GameObject.Find("SpawnBall").transform;
        PinsSpawnPosition = GameObject.Find("SpawnPins").transform;

        NewFrame();
    }

    public void CountScore()
    {
        GameScore += scoredPins;
        if (scoredPins == 10)
        {
            isStrike = true;
        }
        ScoreText.text = "Счет: " + GameScore.ToString();
    }

    void NewFrame()
    {
        scoredPins = 0;
        pins = Instantiate(PinsPref, PinsSpawnPosition.position, PinsSpawnPosition.rotation);
        Instantiate(BallPref, BallSpawnPosition.position, BallSpawnPosition.rotation);

        if (Frame < 20)
        {
            FrameText.text = "Фрейм: " + (Frame / 2 + 1).ToString();
            ThrowText.text = "Бросок: " + (Frame % 2 + 1).ToString();
        }
        else
        {
            EndGame();
        }
    }
    
    public void EndFrame()
    {
        
        Destroy(pins);
        Debug.Log(GameManager.scoredPins);
        CountScore();
        if (isStrike)
        {
            Frame += 2;
            ShowText();
        }
        else
        {
            Frame++;
        }
        NewFrame();
    }

    void EndGame()
    {
        Panel.SetActive(true);
        TotalScoreText.text = "Общий счет: " + GameScore.ToString();
        Time.timeScale = 0;
        Debug.Log("game end");
    }

    public void RestartGame()
    {
        Panel.SetActive(false);
        GameScore = 0;
        Frame = 0;
        Time.timeScale = 1;

        FrameText.text = "Фрейм: " + (Frame / 2 + 1).ToString();
        ScoreText.text = "Счет: " + GameScore.ToString();
        NewFrame();
    }

    void ShowText()
    {
        StrikeText.gameObject.SetActive(true); // Показываем текст
        Invoke("HideText", 5f); // Запланируем скрытие текста через 5 секунд
    }

    void HideText()
    {
        StrikeText.gameObject.SetActive(false); // Скрываем текст
    }

}
