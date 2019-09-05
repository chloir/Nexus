using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class MechSelectionController : MonoBehaviour
{
    [SerializeField] private Transform mechPosition = null;
    [SerializeField] private Vector3 showCaseRotateAngle = new Vector3(0, 0, 0);
    private GameObject _selectedMech = null;

    void Start()
    {
        var obj = Instantiate(_selectedMech, mechPosition.position, Quaternion.identity);

        this.UpdateAsObservable()
            .Subscribe(_ => obj.transform.Rotate(showCaseRotateAngle));
    }

    void Update()
    {
        
    }
}
