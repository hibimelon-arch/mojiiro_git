using UnityEngine;

// 静的クラスはGameObjectにアタッチする必要がなく、どこからでもアクセス可能です
public static class ScoreManager
{
    // public static int で宣言することで、どのシーンからでもこのスコアを参照できます
    public static int CurrentScore = 0;

    // ゲーム開始時やリトライ時にスコアをリセットするメソッド（オプション）
    public static void ResetScore()
    {
        CurrentScore = 0;
    }
}