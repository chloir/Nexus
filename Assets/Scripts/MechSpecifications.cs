using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MechSpecifications : ScriptableObject
{
    public List<MechSpec> MechSpecs = new List<MechSpec>();
}

[System.Serializable]
public class MechSpec
{
    public string mechName = "undefined";
    public int mechId = 0;
    public GameObject mechPrefab = null;
}