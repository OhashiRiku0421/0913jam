using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("スコア")] public static int _score = 0;

    public bool _isPlay = false;
    void Start()
    {
        FadeIn();
    }

    void Update()
    {

    }
    /// <summary>
    /// フェードアウト
    /// </summary>
    public void FadeOut(string sceneName)
    {
        GameObject panel = GameObject.Find("Panel");
        panel.GetComponent<Image>().enabled = true;
        panel.GetComponent<Image>().DOFade(1, 1.5f)
            .SetDelay(0.5f)
            //fadeoutが終わったら呼ばれる
            .OnComplete(() => SceneManager.LoadScene(sceneName));
    }
    /// <summary>
    /// フェードイン
    /// </summary>
    public void FadeIn()
    {
        GameObject panel = GameObject.Find("InPanel");
        //パネルがあったらフェードインする
        if (panel == null)
        {
            return;
        }
        else
        {
            panel.GetComponent<Image>().DOFade(0, 1.5f)
            .SetDelay(0.5f)
            .OnComplete(() => _isPlay = true);
        }

    }
}
