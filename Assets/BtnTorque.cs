using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BtnTorque : BaseButton
{
    [SerializeField] public bool TorqueClicked = false;
    [SerializeField] public Image image;
    protected override void Start()
    {
        base.Start();
        this.GetImage();
        this.TorqueClicked = false;
    }
    protected override void OnClick()
    {
        this.TorqueClicked = true;

    }

    protected virtual void Update()
    {
        this.AdjustFillAmout();
    }

    protected virtual void GetImage()
    {
        this.image = ButtonUICtrl.Instance.imageTorque;
    }

    protected virtual void AdjustFillAmout()
    {

        if (AbilityCtrl.Instance.AbilityTorque.CooldownTime > 0f)
        {
            this.image.fillAmount = 1 / AbilityCtrl.Instance.AbilityTorque.CooldownTime;
        }
    }
}
