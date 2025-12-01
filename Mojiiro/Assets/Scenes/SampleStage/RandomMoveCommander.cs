using UnityEngine;
using TMPro;
using System.Collections.Generic; // リスト機能を使うために必要

public class RandomMoveCommander : MonoBehaviour
{
    [Header("ターゲット設定")]
    public string targetTag = "Target"; // 動かす対象のタグ名
    
    // 配置したい範囲（画面の大きさに合わせて調整してね）
    public Vector2 minPos = new Vector2(-350, -200); 
    public Vector2 maxPos = new Vector2(350, 200);   
    
    [Header("重なり防止")]
    public float minDistance = 150f; // ★ボタン同士の距離（ボタンの大きさより少し大きく！）

    [Header("スコア設定")]
    public TextMeshProUGUI scoreDisplayTMP; // スコア表示用のテキスト
    public bool addScoreOnMove = true;      // スコアを加算するかどうか
    public int scorePerMove = 1;            // 1個動くごとのスコア

    // ★ このメソッドをボタンのOnClickに登録します
    public void CommandAllTargetsToMove()
    {
        // 1. "Target"タグがついた全てのオブジェクトを探す
        GameObject[] targets = GameObject.FindGameObjectsWithTag(targetTag);
        
        if (targets == null || targets.Length == 0) return;

        // 2. 場所決め済みの座標リスト（重なりチェック用）
        List<Vector2> allocatedPositions = new List<Vector2>();
        
        int totalScoreAdded = 0;

        // 3. 全ターゲットに対して順番に処理
        foreach (GameObject targetObj in targets)
        {
            // 重ならない安全な座標を計算して取得
            Vector2 safePos = CalculateSafePosition(allocatedPositions);
            
            // 決定した座標をリストに追加（次の人のチェック用）
            allocatedPositions.Add(safePos);

            // ★ターゲット側のスクリプトにある「MoveToPosition」を実行！
            targetObj.SendMessage("MoveToPosition", safePos, SendMessageOptions.DontRequireReceiver);

            if (addScoreOnMove)
            {
                totalScoreAdded += scorePerMove;
            }
        }

        // 4. スコアをまとめて更新
        if (addScoreOnMove && totalScoreAdded > 0)
        {
            ScoreManager.CurrentScore += totalScoreAdded;
            UpdateScoreDisplay();
        }
    }

    // 重ならない座標を計算するメソッド
    Vector2 CalculateSafePosition(List<Vector2> existingPositions)
    {
        int maxRetries = 50; // 最大50回まで再抽選を試みる

        for (int i = 0; i < maxRetries; i++)
        {
            // ランダムな座標を仮作成
            float x = Random.Range(minPos.x, maxPos.x);
            float y = Random.Range(minPos.y, maxPos.y);
            Vector2 candidate = new Vector2(x, y);

            // 既存の座標と近すぎないかチェック
            bool isTooClose = false;
            foreach (Vector2 pos in existingPositions)
            {
                if (Vector2.Distance(candidate, pos) < minDistance)
                {
                    isTooClose = true;
                    break;
                }
            }

            // 重なっていなければ採用！
            if (!isTooClose)
            {
                return candidate;
            }
        }

        // どうしても場所が見つからない場合は、そのまま返す
        return new Vector2(Random.Range(minPos.x, maxPos.x), Random.Range(minPos.y, maxPos.y));
    }

    // スコア表示を更新する
    void UpdateScoreDisplay()
    {
        if (scoreDisplayTMP != null)
        {
            scoreDisplayTMP.text = ScoreManager.CurrentScore.ToString() + "点";
        }
    }
}