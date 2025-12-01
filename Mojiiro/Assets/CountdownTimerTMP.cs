using UnityEngine;
using TMPro; // TextMeshProを使うときに必要
using UnityEngine.SceneManagement;

public class CountdownTimerTMP : MonoBehaviour
{
    public TextMeshProUGUI timerText; // TextMeshProUGUIを割り当てる
    public float timeRemaining = 30f; // 残り時間（秒）
    public string nextSceneName = "ResultScene"; // 切り替え先シーン名

    private bool isTimeUp = false;

    void Start()
    {
        UpdateTimerDisplay();
    }

    void Update()
    {
        if (!isTimeUp)
        {
            timeRemaining -= Time.deltaTime;

            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                isTimeUp = true;
                TimeUp();
            }

            UpdateTimerDisplay();
        }
    }

    void UpdateTimerDisplay()
    {
        // 残り秒数を整数で表示（例: 29, 28...）
        timerText.text = "残り: " + Mathf.Ceil(timeRemaining).ToString() + " 秒";
    }

    void TimeUp()
    {
        // シーン切り替え
        SceneManager.LoadScene(nextSceneName);
    }
}