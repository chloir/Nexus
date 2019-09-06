using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Security.Cryptography;
using UniRx;
using UniRx.Triggers;
using UnityEngine.SceneManagement;

public class TotalGameManager : MonoBehaviour
{
    [SerializeField] private Fade fade = null;
    private GameObject[] enemies;
    private int enemyCount = 0;
    
    private void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemyCount = enemies.Length;

        this.UpdateAsObservable()
            .First(_ => enemyCount < 1)
            .Subscribe(_ =>
            {
                fade.FadeIn(1, () => { SceneManager.LoadScene("ResultScene"); });
                Debug.Log("Game Clear");
            });
    }

    public void TranslateEnemyCount(int diff)
    {
        enemyCount += diff;
    }
}
