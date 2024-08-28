using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomLeftUICtrl : HoangMonoBehaviour
{
    [SerializeField] protected ButtonUICtrl buttonUICtrl;
    [SerializeField] protected HPbarCtrl hpbarCtrl;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadHpbarCtrl();
        this.LoadButtonUICtrl();
    }

    protected virtual void LoadHpbarCtrl()
    {
        this.hpbarCtrl = GetComponentInChildren<HPbarCtrl>();
    }

    protected virtual void LoadButtonUICtrl()
    {
        this.buttonUICtrl = GetComponentInChildren<ButtonUICtrl>();
    }
}
