using UnityEngine;
using UnityEngine.UI;
using TMPro;

// シーン中の Tag="Target" が付いた全オブジェクトに対して
// ボタンのクリックでランダム移動＋任意のスコア加算などを適用するマネージャ
public class TargetRandomMoveManager : MonoBehaviour
{
    
    public Vector2 minPos = new Vector2(-400, -200);
    public Vector2 maxPos = new Vector2(400, 200);

    public bool addScoreOnMove = false;
    public int scorePerMove = 1;
    public TextMeshProUGUI scoreDisplayTMP; // 任意

    // Start時に全Targetを検出してイベント登録
    void Start()
    {
        {
        if (gameObject.tag == "Target")    // 相手のオブジェクトのタグ名がTargetの場合
        {
            Debug.Log("ランダム配置");  // ダメージを与える処理を書く
        }
    }    
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Target");
        if (targets == null || targets.Length == 0)
        {
            Debug.LogWarning("Target タグ付きオブジェクトが見つかりませんでした。Tag を確認してください。");
            return;
        }

        foreach (GameObject t in targets)
        {
            if (t == null) continue;

            Button btn = t.GetComponent<Button>();
            if (btn != null)
            {
                // capture local variable
                GameObject target = t;
                // 既に登録済みの可能性があるため一度クリア（重複防止）
                btn.onClick.RemoveAllListeners();
                btn.onClick.AddListener(() => OnTargetClicked(target));
                Debug.Log($"Registered click for {target.name}");
            }
            else
            {
                // Button が無い場合は、オブジェクト自身に TargetRandomMoveOnClick のような
                // スクリプトを付与しておくか、Collider経由で処理する必要があります。
                Debug.LogWarning($"{t.name} に Button コンポーネントがありません。Button か別のクリック手段を追加してください。");
            }
        }
    }

    // 各ターゲットがクリックされたときの共通処理
    void OnTargetClicked(GameObject target)
    {
        if (target == null) return;

        RectTransform rt = target.GetComponent<RectTransform>();
        if (rt == null)
        {
            Debug.LogError($"{target.name} に RectTransform がありません。UIボタンではない可能性があります。");
            return;
        }

        float x = Random.Range(minPos.x, maxPos.x);
        float y = Random.Range(minPos.y, maxPos.y);
        rt.anchoredPosition = new Vector2(x, y);
        Debug.Log($"Moved {target.name} -> {rt.anchoredPosition}");

        // オプション: 各ターゲットに固有の挙動を呼び出す
        target.SendMessage("OnActivated", SendMessageOptions.DontRequireReceiver);

        // オプション: スコア加算
        if (addScoreOnMove)
        {
            ScoreManager.CurrentScore += scorePerMove;
            if (scoreDisplayTMP != null)
            {
                scoreDisplayTMP.text = ScoreManager.CurrentScore.ToString() + "点";
            }
            Debug.Log($"Score +{scorePerMove}. CurrentScore={ScoreManager.CurrentScore}");
        }
    }
}
