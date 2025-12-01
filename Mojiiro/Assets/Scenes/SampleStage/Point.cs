using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Point : MonoBehaviour
{
    // 1. 実際の得点を表示しているTextMeshProUGUIコンポーネント
    // Targetオブジェクト自身ではない別のオブジェクトのTMPを参照させます。
    // 例：UI Canvas上の "ScoreDisplay" という名前のTMP
    public TextMeshProUGUI scoreDisplayTMP;
    public Button pointButton; // クリック対象のボタン 

    void Start()
    {
        
        // 初めてゲームを始めた時のために、スコア表示が空なら "0" に設定
        if (scoreDisplayTMP != null && string.IsNullOrEmpty(scoreDisplayTMP.text))
        {
            scoreDisplayTMP.text = "0";
        }

        // ボタンのクリックイベントにメソッドを登録
        if (pointButton != null)
        {
            pointButton.onClick.AddListener(AddScore);
        }
        else
        {
            Debug.LogError("pointButtonが設定されていません。Inspectorで設定してください！");
        }
    }

    // ボタンがクリックされたときに呼ばれるメソッド
    public void AddScore()
    {
        Debug.Log("Button clicked");
        if (scoreDisplayTMP == null)
        {
            Debug.LogError("scoreDisplayTMP is null");
            return;
        }

        // ScoreManager を使用してスコアを管理
        ScoreManager.CurrentScore++;

        // ScoreManager のスコアをテキストに反映
        scoreDisplayTMP.text = ScoreManager.CurrentScore.ToString() + "点";
        
        // 加点されたことをログで確認
        Debug.Log("得点 +1! 現在のスコア: " + ScoreManager.CurrentScore);
    }
}