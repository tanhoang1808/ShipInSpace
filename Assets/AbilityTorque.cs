using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityTorque : BaseAbility
{
    Transform torque;
    abilityCode code;
    [SerializeField] protected List<Transform> points = new List<Transform>();

    protected override void Start()
    {
        this.GetTorPoints();
        this.setLevelToUse();
    }

    protected virtual void GetTorPoints()
    {
        foreach (Transform point in transform)
        {
            this.points.Add(point);
        }
    }


    protected override void Active()
    {
        code = abilityCode.Torque;
        for(int i = 0; i < points.Count;i++)
        {
            torque = this.abilityCtrl.ProjectileSpawner.Spawn(code.ToString(), points[i].position, points[i].rotation);
            torque.transform.GetComponent<TorqueCtrl>().SetShooter(transform.parent.parent);
            torque.gameObject.SetActive(true);
        }
    }

    

    protected override bool GetKeyDown()
    {
        if( abilityCtrl.InputManager.PressZ() && abilityCtrl.shipCtrl.level >= this.LevelToUse) return true;
        else if (ButtonUICtrl.Instance.TorqueButton.GetComponent<BtnTorque>().TorqueClicked && abilityCtrl.shipCtrl.level >= this.LevelToUse)
        {
            ButtonUICtrl.Instance.TorqueButton.GetComponent<BtnTorque>().TorqueClicked = false;

            return true;
        }
        return false;
    }

    protected override void setLevelToUse()
    {
        this.LevelToUse = this.ability.levelToUse;
    }
}
