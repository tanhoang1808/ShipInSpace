using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleUICtrl : HoangMonoBehaviour
{
    [SerializeField] protected static MiddleUICtrl instance;
    [SerializeField] public static MiddleUICtrl Instance => instance;
    [SerializeField] protected WaveDisplay waveDisPlay;
    protected override void Awake()
    {
        base.Awake();
        instance = this;
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadWaveDisPlay();
    }

    protected virtual void LoadWaveDisPlay()
    {
        this.waveDisPlay = GetComponentInChildren<WaveDisplay>();
    }
}
