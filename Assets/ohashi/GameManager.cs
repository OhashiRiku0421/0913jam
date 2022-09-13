using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int _score = 0;

    void Start()
    {
        
    }

    void Update()
    {
       
    }
    public void FadeOut(string sceneName)
    {
        GameObject panel = GameObject.Find("Panel");
        panel.GetComponent<Image>().enabled = true;
        panel.GetComponent<Image>().DOFade(1, 1.5f)
            .SetDelay(0.5f)
            //fadeout‚ªI‚í‚Á‚½‚çŒÄ‚Î‚ê‚é
            .OnComplete(() => SceneManager.LoadScene(sceneName));
    }
    public void FadeIn()
    {

    }
}
