using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

public class AimController : MonoBehaviour
{
    [SerializeField] private Image reticle;
    [SerializeField] private Camera mainCamera;
    void Start()
    {
        //offset = transform.position - player.transform.position;
        
        var aimPos = new ReactiveProperty<Vector3>();
        aimPos.Value = transform.position;

        aimPos.AsObservable()
            .Subscribe(_ =>
                reticle.transform.position = RectTransformUtility.WorldToScreenPoint(mainCamera, aimPos.Value));
    }
}
