using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage2_Button2_Script : MonoBehaviour

{
    public Vector3 speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += speed * Time.deltaTime;
        if (transform.position.x >= 10 || transform.position.x <= -10)
        {
            speed *= -1;
        }
        
    }
    public void Button2Click()
    {
        SceneManager.LoadScene("Title_Scene");
    }
}
