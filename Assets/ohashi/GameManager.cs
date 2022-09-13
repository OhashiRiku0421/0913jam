using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int _score = 0;
    //public static GameManager _instance;
    //void Awake()
    //{
    //    if(_instance == null)
    //    {
    //        _instance = this;
    //        DontDestroyOnLoad(gameObject);
    //    }
    //    else
    //    {
    //        Destroy(gameObject);
    //    }
    //}
    void Start()
    {
        FadeIn();
    }

    void Update()
    {

    }
    /// <summary>
    /// �t�F�[�h�A�E�g
    /// </summary>
    /// <param name="sceneName"></param>
    public void FadeOut(string sceneName)
    {
        GameObject panel = GameObject.Find("Panel");
        panel.GetComponent<Image>().enabled = true;
        panel.GetComponent<Image>().DOFade(1, 1.5f)
            .SetDelay(0.5f)
            //fadeout���I�������Ă΂��
            .OnComplete(() => SceneManager.LoadScene(sceneName));
    }
    public void FadeIn()
    {
        GameObject panel = GameObject.Find("InPanel");
        if (panel == null)
        {
            return;
        }
        else
        {
            panel.GetComponent<Image>().DOFade(0, 1.5f)
            .SetDelay(0.5f);
        }

    }
}
