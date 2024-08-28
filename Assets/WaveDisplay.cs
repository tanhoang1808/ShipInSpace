using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class WaveDisplay : HoangMonoBehaviour
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
        this.textMesh.text = "Wave: " + EnemySpawnWave.Instance.currentWave + " / " + EnemySpawnWave.Instance.maxWave;
    }

}
