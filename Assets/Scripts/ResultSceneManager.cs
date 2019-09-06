using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultSceneManager : MonoBehaviour
{
    [SerializeField] private Fade fade = null;
    
    void Start()
    {
        fade.FadeIn(0, () => fade.FadeOut(1));
        
        this.UpdateAsObservable()
            .Where(_ => Input.GetKeyDown(KeyCode.Space))
            .Subscribe(_ => SceneManager.LoadScene("TitleScene"));
    }
}
