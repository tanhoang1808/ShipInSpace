using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealChanged : MonoBehaviour
{
    [SerializeField] protected Image image;

    protected virtual void Awake()
    {
        this.image = GetComponent<Image>();
    }

    protected virtual void ChecklPlayerHealth()
    {
        this.image.fillAmount = ShipCtrl.Instance.DamageReceiver.Hp / ShipCtrl.Instance.DamageReceiver.HpMax;
    }
    protected virtual void Update()
    {
        this.ChecklPlayerHealth();
    }



    protected virtual void Start()
    {
        this.image.fillAmount = ShipCtrl.Instance.DamageReceiver.Hp / ShipCtrl.Instance.DamageReceiver.HpMax;
    }
}
