using UnityEngine;

public class TargetCommander : MonoBehaviour
{
    // ターゲットオブジェクトに設定しているタグ名
    public string targetTag = "Target";

    // 実行したいメソッド名（ターゲットスクリプトにpublicで定義されている必要あり）
    public string methodName = "MyTargetAction";

    // ボタンなどを押したときに呼び出す public メソッド
    public void ExecuteOnAllTargets()
    {
        // 1. 指定されたタグを持つすべてのゲームオブジェクトを配列で取得
        GameObject[] targets = GameObject.FindGameObjectsWithTag(targetTag);
        
        if (targets == null || targets.Length == 0)
        {
            Debug.LogWarning($"タグ '{targetTag}' の付いたオブジェクトが見つかりませんでした。");
            return;
        }

        // 2. 取得した配列を一つずつループ処理する
        foreach (GameObject targetObj in targets)
        {
            // 3. 各ターゲットオブジェクトに対してメソッドを実行する
            // SendMessage は、オブジェクトにアタッチされた全スクリプトの指定メソッドを探して呼び出します
            targetObj.SendMessage(methodName, SendMessageOptions.DontRequireReceiver);
            
            // DontRequireReceiver は、メソッドが存在しなくてもエラーを出さないようにするオプションです
            Debug.Log($"ターゲット: {targetObj.name} に '{methodName}' を実行しました。");
        }
    }
}