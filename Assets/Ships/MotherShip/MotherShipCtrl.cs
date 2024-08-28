using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShipCtrl : HoangMonoBehaviour
{
    protected static MotherShipCtrl instance;
    [SerializeField] public static MotherShipCtrl Instance => instance;

    [SerializeField] protected AudioCtrl audioCtrl;
    public AudioCtrl AudioCtrl => audioCtrl;

    protected override void Awake()
    {
        if (MotherShipCtrl.instance != null) Debug.LogWarning("Exceed instance MotherShipCtrl");
        instance = this;
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadAudioCtrl();
    }

    protected virtual void LoadAudioCtrl()
    {
        audioCtrl = FindObjectOfType<AudioCtrl>();
    }


}
