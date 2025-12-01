using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Point_Discount : MonoBehaviour
{
    // 1. 実際の得点を表示しているTextMeshProUGUIコンポーネント
    // スコア表示を更新するために使用します。
    public TextMeshProUGUI scoreDisplayTMP; 
    
    // UIボタンから減算したい場合に割り当てる
    public Button pointButton; 
    
    // 減算するポイント数
    public int discountAmount = 1; 

    void Start()
    {
        // 🚨 注意点: ここで ScoreManager.CurrentScore++; を行うと、
        // このオブジェクトが生成されるたびにスコアが増えてしまうため、削除しました。
        // スコアの初期化（リセット）は、ゲーム開始前のシーンで行うのが理想的です。
        
        // スコア表示用TMPが設定されていない場合のエラーチェック
        if (scoreDisplayTMP == null)
        {
            Debug.LogError("スコア表示用のTextMeshProUGUIが設定されていません。Inspectorで設定してください！");
            // スコア表示ができないので、ここで処理を止めるか、注意を促すべきです
        }

        // UI ボタンが割り当てられていればクリックリスナーを登録
        if (pointButton != null)
        {
            // ボタンが押されたら DecrementScore を呼び出すように設定
            pointButton.onClick.AddListener(DecrementScore);
        }
    }

    // Targetオブジェクトがクリックされたときに呼ばれるメソッド
    void OnMouseDown()
    {
        Debug.Log("Point_Discount OnMouseDown called (Target Click)");
        DecrementScore();
    }

    // ★ 数値部分を抽出する複雑な処理を削除し、ScoreManagerと連携
    // OnButtonClickedと統合し、引数なしの共通メソッドにします
    public void DecrementScore()
    {
        if (scoreDisplayTMP == null)
        {
            return;
        }

        // ★ 1. ScoreManagerの静的スコアを減算する
        ScoreManager.CurrentScore -= discountAmount;

        // ★ 2. 減算後のスコアを画面に反映する
        // ここで「点」という文字列を付与して表示します。
        scoreDisplayTMP.text = ScoreManager.CurrentScore.ToString() + "点";

        Debug.Log("得点 -" + discountAmount + "! 現在のスコア: " + ScoreManager.CurrentScore);
    }
}