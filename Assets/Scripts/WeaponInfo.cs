using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WeaponInfo : ScriptableObject
{
    public List<WeaponDetail> weaponInfoList = new List<WeaponDetail>();
}

[System.Serializable]
public class WeaponDetail
{
    public string name = String.Empty;
    public int maxAmmo = 0;
    public float velocity = 0;
    public GameObject bulletPrefab = null;
}
