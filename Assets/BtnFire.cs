using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BtnFire : BaseButton
{
    [SerializeField] public bool FireClicked = false;
    [SerializeField] public Image image;
    protected override void Start()
    {
        base.Start();
        this.GetImage();
        this.FireClicked = false;
    }
    protected override void OnClick()
    {
        this.FireClicked = true;

    }

    protected virtual void Update()
    {
        this.AdjustFillAmout();
    }

    protected virtual void GetImage()
    {
        this.image = ButtonUICtrl.Instance.imageFire;
    }

    protected virtual void AdjustFillAmout()
    {

        if (AbilityCtrl.Instance.AbilityFire.CooldownTime > 0f)
        {
            this.image.fillAmount = 1 / AbilityCtrl.Instance.AbilityFire.CooldownTime;
        }
    }
}
