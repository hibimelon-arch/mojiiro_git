using UnityEngine;
using UnityEngine.UI;

public class GameControllerManager : MonoBehaviour
{
    // GameController タグが付いているすべてのオブジェクトを管理
    private GameObject[] gameControllers;
    
    // ボタンが移動する範囲（キャンバスの座標）
    public Vector2 minPos = new Vector2(-400, -200);
    public Vector2 maxPos = new Vector2(400, 200);

    void Start()
    {
        // GameController タグが付いているすべてのオブジェクトを取得
        gameControllers = GameObject.FindGameObjectsWithTag("GameController");
        
        if (gameControllers.Length == 0)
        {
            Debug.LogWarning("GameController タグが付いているオブジェクトが見つかりません");
            return;
        }

        Debug.Log($"GameController タグ付きオブジェクト {gameControllers.Length} 個を検出しました");

        // 各オブジェクトにクリックイベントを登録
        foreach (GameObject controller in gameControllers)
        {
            Button button = controller.GetComponent<Button>();
            if (button != null)
            {
                // ボタンのクリックイベントにランダム移動メソッドを登録
                button.onClick.AddListener(() => MoveToRandomPosition(controller));
                Debug.Log($"クリックイベント登録: {controller.name}");
            }

            // OnMouseDown でも対応できるように Collider を確認
            Collider collider = controller.GetComponent<Collider>();
            if (collider != null)
            {
                Debug.Log($"Collider 検出: {controller.name}");
            }
        }
    }

    // クリックされたオブジェクトをランダムな座標に移動
    public void MoveToRandomPosition(GameObject targetObject)
    {
        RectTransform rectTransform = targetObject.GetComponent<RectTransform>();
        if (rectTransform == null)
        {
            Debug.LogError($"{targetObject.name} に RectTransform がありません");
            return;
        }

        // ランダムな座標を生成
        float randomX = Random.Range(minPos.x, maxPos.x);
        float randomY = Random.Range(minPos.y, maxPos.y);

        // オブジェクトの位置を更新
        rectTransform.anchoredPosition = new Vector2(randomX, randomY);
        
        Debug.Log($"{targetObject.name} を移動: {rectTransform.anchoredPosition}");
    }
}
