using System.Collections;
using System.Collections.Generic;
using UnityEditor.Media;
using UnityEngine;

public abstract class PowerupEffect : ScriptableObject
{
    public abstract void Apply(GameObject target);
}
