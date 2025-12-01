using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GManager : MonoBehaviour
{
    public static GManager instance = null;

    // シーン間で共有したい変数を宣言
    // アクセスする際の例：  GManager.instance.totalScore += 10;
    public int totalScore = 0;

    // SampleStage用
    public int sample = 0;

    // 各ステージ用の変数
    public int stage1 = 0;
    public int stage2 = 0;
    public int stage3 = 0;
    public int stage4 = 0;
    public int stage5 = 0;
    public int stage6 = 0;
    public int stage7 = 0;
    public int stage8 = 0;
    public int stage9 = 0;
    public int stage10 = 0;
    public int stage11 = 0;
    public int stage12 = 0;
    public int stage13 = 0;
    public int stage14 = 0;
    public int stage15 = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }


}