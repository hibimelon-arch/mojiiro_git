using UnityEngine;
using UnityEngine.UI; 
using TMPro;

public class TargetAction : MonoBehaviour
{
    // 移動範囲はそのまま
    public Vector2 minPos = new Vector2(-400, -200);
    public Vector2 maxPos = new Vector2(400, 200);
    
    // スコア処理はCommander側で制御するので、ここはシンプルに
    // public bool addScoreOnMove = true; などの設定は不要になります
    
    private RectTransform rectTransform; 

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        if (rectTransform == null)
        {
            Debug.LogError("このスクリプトは RectTransform が必要です。（UI ボタン用）");
            return;
        }
        
        // 🚨 注意: targetButton.onClick.AddListener の設定は、
        // 司令塔で一括実行するため、ここでは不要なので削除します。
    }
    
    // ★ 司令塔から呼び出されるメソッド
    // このメソッドが実行されると、このボタン自身の位置が変わります。
    public void MoveToRandomPosition()
    {
        float x = Random.Range(minPos.x, maxPos.x);
        float y = Random.Range(minPos.y, maxPos.y);
        
        rectTransform.anchoredPosition = new Vector2(x, y);

        Debug.Log($"Moved {gameObject.name} -> {rectTransform.anchoredPosition}");
        
        // ★ ここでスコア加算処理を加えても良いですが、
        // 今回は「移動させる」機能に集中させます。
    }
    
    // 衝突判定やスコア更新のメソッド（今回は省略）
    // ...
}