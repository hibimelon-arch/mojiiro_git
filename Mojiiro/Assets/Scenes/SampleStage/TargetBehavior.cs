using UnityEngine;
using TMPro;

// ターゲット固有の挙動を提供するコンポーネント
// Random_Position から SendMessage("OnActivated") で呼ばれることを想定しています。
public class TargetBehavior : MonoBehaviour
{
    [Tooltip("OnActivated 呼び出しで加算するスコア量（ScoreManager に加算されます）")]
    public int bonusPoints = 1;

    [Tooltip("任意: このターゲットから直接スコア表示を更新したい場合に割り当ててください（省略可）")]
    public TextMeshProUGUI scoreDisplayTMP;

    [Tooltip("任意: 再生するサウンド（省略可）")]
    public AudioClip activateSfx;
    [Range(0f,1f)]
    public float sfxVolume = 1f;

    AudioSource audioSource;
    Animator animator;

    void Awake()
    {
        // コンポーネントをキャッシュ。AudioSource が無ければ必要時に追加します。
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        if (audioSource == null && activateSfx != null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
        }
    }

    // Random_Position などから SendMessage で呼び出されます
    public void OnActivated()
    {
        // ScoreManager に対してスコアを加算（ScoreManager クラスが存在する前提）
        ScoreManager.CurrentScore += bonusPoints;

        // 任意で即時スコア表示を更新
        if (scoreDisplayTMP != null)
        {
            scoreDisplayTMP.text = ScoreManager.CurrentScore.ToString() + "点";
        }

        // 任意の効果音を再生
        if (audioSource != null && activateSfx != null)
        {
            audioSource.PlayOneShot(activateSfx, sfxVolume);
        }

        // 任意のアニメーション（Animator に "Activated" トリガーをつけておく）
        animator?.SetTrigger("Activated");

        Debug.Log($"{name} OnActivated: +{bonusPoints} -> CurrentScore={ScoreManager.CurrentScore}");
    }
}
