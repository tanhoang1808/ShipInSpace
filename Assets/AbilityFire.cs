using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityFire : BaseAbility
{
    Transform fire;
    abilityCode code;
    [SerializeField] protected List<Transform> points = new List<Transform>();

    
    protected override void Start()
    {
        this.GetFirePoints();
        this.setLevelToUse();
    }

    protected virtual void GetFirePoints()
    {
        foreach (Transform point in transform)
        {
            this.points.Add(point);
        }
    }


    protected override void Active()
    {
        code = abilityCode.Fire;
        for (int i = 0; i < points.Count; i++)
        {
            fire = this.abilityCtrl.ProjectileSpawner.Spawn(code.ToString(), points[i].position, points[i].rotation);
            fire.transform.GetComponent<FireCtrl>().SetShooter(transform.parent.parent);
            //AudioCtrl.Instance.FireProjectileFX();
            fire.gameObject.SetActive(true);
        }
    }

    protected override void InActive()
    {

    }

    protected override bool GetKeyDown()
    {
        if (abilityCtrl.InputManager.PressX() && abilityCtrl.shipCtrl.level >= this.LevelToUse) return true;
        else if (ButtonUICtrl.Instance.FireButton.GetComponent<BtnFire>().FireClicked && abilityCtrl.shipCtrl.level >= this.LevelToUse)
        {
            ButtonUICtrl.Instance.FireButton.GetComponent<BtnFire>().FireClicked = false;

            return true;
        }
        return false;
    }

    protected override void setLevelToUse()
    {
        this.LevelToUse = this.ability.levelToUse;
    }
}
