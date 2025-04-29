using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/DualShooter")]
public class DualShooterBuff : PowerupEffect
{
    bool duoshooting;
    public override void Apply(GameObject target)
    {
        duoshooting = true;
        target.GetComponent<Player>().SetDualShooter(duoshooting);
    }
}
