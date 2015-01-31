using UnityEngine;
using System.Collections;

public class NoRightClick : ShooterAbility {

    public NoRightClick(Shooter shooter)
      : base(shooter)
    {
        this.abilityName = " ";
    }
}
