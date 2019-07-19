using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    [SerializeField] private int AP = 20;
    [SerializeField] private int Damage = 11;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("bullet"))
        {
            Destroy(gameObject);
        }

//        if (AP < 0)
//        {
//            Destroy(gameObject);
//        }
    }
}
