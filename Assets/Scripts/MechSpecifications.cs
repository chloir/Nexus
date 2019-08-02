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
    public float velocityMulti = 0;
    public float boostVelocity = 0;
    public float jumpVelovity = 0;
    public float quickJumpVelocity = 0;
}