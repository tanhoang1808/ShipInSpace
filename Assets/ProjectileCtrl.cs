using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCtrl : HoangMonoBehaviour
{
    [SerializeField] public AbilityCtrl abilityCtrl;
    [SerializeField] protected AbilityCtrl AbilityCtrl => abilityCtrl;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadAbilityCtrl();
    }

    protected virtual void LoadAbilityCtrl()
    {
        this.abilityCtrl = Transform.FindObjectOfType<AbilityCtrl>();
    }
}
