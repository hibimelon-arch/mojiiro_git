using UnityEngine;
using UnityEngine.UI; // Button コンポーネントを使う場合に必要
using TMPro;

public class Commander : MonoBehaviour
{
    // ターゲットオブジェクトに設定しているタグ名
    public string targetTag = "Target"; 
    
    // オプション: 画面上のスコア表示を更新するための TextMeshProUGUI（設定は任意）
    public TextMeshProUGUI scoreDisplayTMP;

    // スコア加算の設定
    public bool addScoreOnMove = true;
    public int scorePerMove = 1;


    // このスクリプトがアタッチされたボタンのOnClickに登録するメソッド
    public void CommandAllTargetsToMove()
    {
        // 1. 指定されたタグを持つ全てのゲームオブジェクトを配列で取得
        GameObject[] targets = GameObject.FindGameObjectsWithTag(targetTag);
        
        if (targets == null || targets.Length == 0)
        {
            Debug.LogWarning($"タグ '{targetTag}' の付いたオブジェクトが見つかりませんでした。");
            return;
        }

        int totalAdded = 0;

        // 2. 取得した配列を一つずつループ処理する
        foreach (GameObject targetObj in targets)
        {
            // 3. 各ターゲットに「ランダム移動しなさい」という命令（メソッド）を実行させる
            // ターゲット側のスクリプトで MoveToRandomPosition() メソッドが public で定義されている必要があります
            targetObj.SendMessage("MoveToRandomPosition", SendMessageOptions.DontRequireReceiver);
            
            // 4. スコアを累積
            if (addScoreOnMove)
            {
                totalAdded += scorePerMove;
            }
        }

        // 5. スコアをまとめて更新
        if (addScoreOnMove && totalAdded != 0)
        {
            // ScoreManager が存在する前提で加算
            ScoreManager.CurrentScore += totalAdded;

            if (scoreDisplayTMP != null)
            {
                scoreDisplayTMP.text = ScoreManager.CurrentScore.ToString() + "点";
            }
            Debug.Log($"全てのターゲットを移動させました。Score +{totalAdded}. CurrentScore: {ScoreManager.CurrentScore}");
        }
    }
}