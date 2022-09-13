using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("スコア")] public static int _score = 0;
    [SerializeField] Text _scoreText;
    [SerializeField] Text _timeText;
    public bool isPlay = false;
    bool isPanel = false;
    [SerializeField] float timer = 60;
    
    void Start()
    {
        FadeIn();
    }

    void Update()
    {
        if (isPlay && !isPanel)
        {
            GameObject panel = GameObject.Find("InPanel");
            panel.GetComponent<Image>().enabled = false;
            isPanel = true;
        }
        Timer();
        Score();
    }
    void Score()
    {
        if (_scoreText != null)
        {
            _scoreText.text = _score.ToString("D5");
        }
    }
    void Timer()
    {
        if (isPlay)
        {
            timer -= Time.deltaTime;
        }
        if (_timeText != null && timer >= 0.001f)
        {
            _timeText.text = timer.ToString("F2");
        }
        else if (timer <= 0.00f)
        {
            FadeOut("result1");
        }
    }
    /// <summary>
    /// フェードアウト
    /// </summary>
    public void FadeOut(string sceneName)
    {
        isPlay = false;
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
            .OnComplete(() => isPlay = true);
        }
    }
    public void Reset()
    {
        _score = 0;
    }
}
