using UnityEngine;
using TMPro;

public class Random_Position : MonoBehaviour
{
    // 移動範囲（UI の RectTransform.anchoredPosition / ワールド座標の XY として使用）
    public Vector2 minPos = new Vector2(-400, -200);
    public Vector2 maxPos = new Vector2(400, 200);

    // オプション: 移動時にスコアを加算する
    public bool addScorePerTarget = false;
    public int scorePerTarget = 1;

    // オプション: 画面上のスコア表示を更新するための TextMeshProUGUI（設定は任意）
    public TextMeshProUGUI scoreDisplayTMP;

    // ボタンの OnClick に割り当てるための public メソッド
    // ボタンが押されたときに、タグ "Target" が付いたすべてのオブジェクトをランダム移動します
    public void MoveAllTargetsRandomly()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Target");
        if (targets == null || targets.Length == 0)
        {
            Debug.LogWarning("Target タグが付いたオブジェクトが見つかりませんでした。");
            return;
        }

        int totalAdded = 0;

        foreach (GameObject obj in targets)
        {
            if (obj == null) continue;

            // UI ボタンなど RectTransform を持つ場合は anchoredPosition を更新
            RectTransform rt = obj.GetComponent<RectTransform>();
            if (rt != null)
            {
                float x = Random.Range(minPos.x, maxPos.x);
                float y = Random.Range(minPos.y, maxPos.y);
                rt.anchoredPosition = new Vector2(x, y);
                Debug.Log($"Moved UI Target {obj.name} -> {rt.anchoredPosition}");
            }
            else
            {
                // RectTransform がない場合は通常の Transform.position を更新（ワールド座標）
                float wx = Random.Range(minPos.x, maxPos.x);
                float wy = Random.Range(minPos.y, maxPos.y);
                Vector3 newPos = new Vector3(wx, wy, obj.transform.position.z);
                obj.transform.position = newPos;
                Debug.Log($"Moved World Target {obj.name} -> {newPos}");
            }

            // 各ターゲットに固有の挙動があれば呼び出す（任意）。
            // 例: 各ターゲットに "OnActivated" という public メソッドを用意しておくと呼べる。
            obj.SendMessage("OnActivated", SendMessageOptions.DontRequireReceiver);

            // オプション: スコアを累積
            if (addScorePerTarget)
            {
                totalAdded += scorePerTarget;
            }
        }

        // スコアをまとめて更新（ScoreManager を使っている前提）
        if (addScorePerTarget && totalAdded != 0)
        {
            // ScoreManager が存在する前提で加算
            ScoreManager.CurrentScore += totalAdded;

            // 画面表示が設定されていれば更新
            if (scoreDisplayTMP != null)
            {
                scoreDisplayTMP.text = ScoreManager.CurrentScore.ToString() + "点";
            }

            Debug.Log($"Total score added: {totalAdded}. CurrentScore: {ScoreManager.CurrentScore}");
        }
    }
}
