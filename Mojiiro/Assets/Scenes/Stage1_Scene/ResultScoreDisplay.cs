using UnityEngine;
using TMPro;

public class ResultScoreDisplay : MonoBehaviour
{
    private TextMeshProUGUI resultText;

    void Start()
    {
        // このスクリプトがアタッチされているTMPを取得
        resultText = GetComponent<TextMeshProUGUI>();

        // ★ 最終スコアを静的クラスから取得
        int finalScore = ScoreManager.CurrentScore;

        // 取得したスコアを画面に表示
        resultText.text = "最終スコア: " + finalScore.ToString() + "点";
        
        // オプション: スコア表示後、次のゲームのために静的スコアをリセットしておく
        ScoreManager.ResetScore();
    }
}