// using UnityEngine;

// public class NewMonoBehaviourScript : MonoBehaviour
// {
//     // Start is called once before the first execution of Update after the MonoBehaviour is created
//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }
// }

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountDownGame : MonoBehaviour
{
    public float timer = 60f;
    public string nextSceneName = "Stage1_Scene";

    // TextMeshProUGUIにしている場合は、型を適宜変更してください
    public Text timerText; 
    
    private bool isTimeUp = false; 

    // Startは最初のフレームの前に一度だけ呼ばれます
    void Start()
    {
        if (timerText == null)
        {
            timerText = GetComponent<Text>();
        }
        
        // 整数表示
        timerText.text = Mathf.FloorToInt(timer).ToString();
    }

    // Updateは毎フレーム呼ばれます
    void Update()
    {
        if (isTimeUp) 
        {
            return;
        }

        // timerの値を直接操作する代わりに、ここで時間を進める
        timer -= Time.deltaTime;
        
        // 表示用の整数値を取得
        int displayTime = Mathf.FloorToInt(timer);
        
        if (displayTime <= 0)
        {
            // 0になった瞬間の処理
            
            timer = 0f; // 念のため0に固定
            timerText.text = "残り:0秒";
            isTimeUp = true; 
            
            // シーン遷移
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            // 整数値のみを表示
            timerText.text ="残り:" + displayTime.ToString() + "秒";
        }
    }
}