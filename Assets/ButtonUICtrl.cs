using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonUICtrl : HoangMonoBehaviour
{
    [SerializeField] protected static ButtonUICtrl instance;
    [SerializeField] public static ButtonUICtrl Instance => instance;
    [SerializeField] protected Button fireButton;
    [SerializeField] public Button FireButton => fireButton;
    [SerializeField] protected Button torqueButton;
    [SerializeField] public Button TorqueButton => torqueButton;
    [SerializeField] protected Button destroyButton;
    [SerializeField] public Button DestroyButton => destroyButton;
    [SerializeField] public bool isDestroyClicked = false;
    [SerializeField] public Image imageDestroy;
    [SerializeField] public Image imageFire;
    [SerializeField] public Image imageTorque;
    protected override void Awake()
    {
        if (ButtonUICtrl.instance != null) Debug.LogWarning("Exceed ButtonUICtrl");
        instance = this;
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadfireButton();
        this.LoadTorqueButton();
        this.LoadDestroyButton();
        this.GetDestroyImage();
        this.GetFire();
        this.GetTorque();
    }

    protected virtual void LoadfireButton()
    {
        this.fireButton = transform.Find("Fire").GetComponent<Button>();
    }
    protected virtual void LoadTorqueButton()
    {
        this.torqueButton = transform.Find("Torque").GetComponent<Button>();
    }
    protected virtual void LoadDestroyButton()
    {
        this.destroyButton = transform.Find("Destroy").GetComponent<Button>();
    }

    protected virtual void GetDestroyImage()
    {
        imageDestroy = transform.Find("Destroy").Find("Slider").GetComponentInChildren<Image>();
        
    }
    protected virtual void GetFire()
    {
        imageFire = transform.Find("Fire").Find("Slider").GetComponentInChildren<Image>();

    }
    protected virtual void GetTorque()
    {
        imageTorque = transform.Find("Torque").Find("Slider").GetComponentInChildren<Image>();

    }

}
