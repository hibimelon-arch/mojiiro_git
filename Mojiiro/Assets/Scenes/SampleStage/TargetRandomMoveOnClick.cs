using UnityEngine;

public class TargetRandomMoveOnClick : MonoBehaviour
{
    private RectTransform rectTransform;

    void Awake()
    {
        // 自分の位置情報コンポーネントを取得しておく
        rectTransform = GetComponent<RectTransform>();
    }

    // ★ 司令塔から呼び出される「移動専用」のメソッド
    // 引数で「新しい座標」を受け取ります
    public void MoveToPosition(Vector2 newPos)
    {
        if (rectTransform != null)
        {
            rectTransform.anchoredPosition = newPos;
        }
    }
}