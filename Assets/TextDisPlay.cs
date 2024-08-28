using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TextDisPlay : HoangMonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI textMesh;

    protected override void Awake()
    {
        this.textMesh = GetComponent<TextMeshProUGUI>();
    }
    protected virtual void Update()
    {
        this.DisPlay();
    }
    protected virtual void DisPlay()
    {
        this.textMesh.text = "Level " + ShipCtrl.Instance.level;
    }
}
