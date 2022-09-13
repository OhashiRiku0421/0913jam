using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("�X�R�A")] public static int _score = 0;

    public bool _isPlay = false;
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
    public void FadeOut(string sceneName)
    {
        GameObject panel = GameObject.Find("Panel");
        panel.GetComponent<Image>().enabled = true;
        panel.GetComponent<Image>().DOFade(1, 1.5f)
            .SetDelay(0.5f)
            //fadeout���I�������Ă΂��
            .OnComplete(() => SceneManager.LoadScene(sceneName));
    }
    /// <summary>
    /// �t�F�[�h�C��
    /// </summary>
    public void FadeIn()
    {
        GameObject panel = GameObject.Find("InPanel");
        //�p�l������������t�F�[�h�C������
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
