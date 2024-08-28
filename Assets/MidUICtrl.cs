using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidUICtrl : HoangMonoBehaviour
{
    [SerializeField] protected DeadPanel deadPanel;
    [SerializeField] public DeadPanel DeadPanel => deadPanel;
    [SerializeField] protected PausePanel pausePanel;
    [SerializeField] public PausePanel PausePanel => pausePanel;


    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadDeadPanel();
        this.LoadPausePanel();
    }

    protected virtual void LoadDeadPanel()
    {
        this.deadPanel = GetComponentInChildren<DeadPanel>();
    }

    protected virtual void LoadPausePanel()
    {
        this.pausePanel = GetComponentInChildren<PausePanel>();
    }

    protected virtual void Start()
    {
        this.deadPanel.gameObject.SetActive(false);
        this.pausePanel.gameObject.SetActive(false);
    }

}
