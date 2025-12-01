// using UnityEngine;
// using UnityEngine.UI;
// using UnityEngine.SceneManagement;

// public class CountDownScript2 : MonoBehaviour
// {
//     [SerializeField] float timer = 3f;
//     [SerializeField] string nextSceneName;

//     Text timerText;

//     /*
//     GameObject instructionImageObj;
//     [SerializeField] float instructionTimer = 3f;
//     */

//     // Start is called once before the first execution of Update after the MonoBehaviour is created
//     void Start()
//     {
//         timerText = GetComponent<Text>();
//         timerText.text = (Mathf.Floor(timer * 10) / 10).ToString();

//         /*
//         instructionImageObj = transform.Find("Image").gameObject;
//         instructionImageObj.SetActive(true);
//         timerText.text = "�J�n�܂�:" + (Mathf.Floor(timer * 10) / 10) + "�b";
//         */
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         /*
//         instructionTimer -= Time.deltaTime;
//         if(instructionTimer >= 0)
//         {
//             timerText.text = "�J�n�܂�:" + (Mathf.Floor(instructionTimer * 10) / 10) + "�b";
//             return;
//         }
//         else if(instructionImageObj.activeSelf)
//         {
//             instructionImageObj.SetActive(false);
//         }
//         */



//         timer -= Time.deltaTime;
        
//         if (timer <= 0)
//         {
//             timerText.text = 0.ToString();
//             SceneManager.LoadScene(nextSceneName);
//         }
//         else
//         {
//             timerText.text = (Mathf.Floor(timer * 10) / 10).ToString();
//         }
//     }
// }

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerController : MonoBehaviour
{
    public float timer = 60f;
    public string nextSceneName = "GameOverScene";

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
            timerText.text = 0.ToString();
            isTimeUp = true; 
            
            // シーン遷移
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            // 整数値のみを表示
            timerText.text = displayTime.ToString();
        }
    }
}