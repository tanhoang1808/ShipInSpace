using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BtnDestroy : BaseButton
{
    [SerializeField] public bool DestroyClicked = false;
    [SerializeField] public Image image;
    protected override void Start()
    {
        base.Start();
        this.GetImage();
        this.DestroyClicked = false;
    }
    protected virtual void Update()
    {
        this.AdjustFillAmout();
    }

    protected override void OnClick()
    {
        this.DestroyClicked = true;
        
    }
    

    protected virtual void GetImage()
    {
        this.image = ButtonUICtrl.Instance.imageDestroy;
    }

    protected virtual void AdjustFillAmout()
    {

        if( AbilityCtrl.Instance.AbilityDestroy.CooldownTime > 0f)
        {
            this.image.fillAmount = 1 / AbilityCtrl.Instance.AbilityDestroy.CooldownTime;
        }

        
        
    }
}
