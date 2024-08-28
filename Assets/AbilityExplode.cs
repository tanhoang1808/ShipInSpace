using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityExplode : BaseAbility
{
    Transform explode;
    abilityCode code;
    


    protected override void Start()
    {
        
        this.setLevelToUse();
    }

    

    protected override void Active()
    {
        
    }

    protected override void InActive()
    {

    }

    protected override bool GetKeyDown()
    {
        return true;
    }

    protected override void setLevelToUse()
    {
        this.LevelToUse = this.ability.levelToUse;
    }
}
