using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage1_Button1_Script : MonoBehaviour

{
    public Vector3 speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // transform.position += speed * Time.deltaTime;
        // if (transform.position.x >= 10 || transform.position.x <= -10)
        {
            // speed *= -1;
        }
        
    }
    public void Button1Click()
    {
        // GManager.instance.stage1 = 1;
        // GManager.instance.totalScore += 1;
        SceneManager.LoadScene("Title_Scene");
    }
}
