using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Enemy", menuName = "EnemySO/Enemy")]
public class EnemySO : ScriptableObject
{
    [SerializeField] public int hpMax = 3;
    [SerializeField] protected string enemyName = "Enemy";
    [SerializeField] public int cost = 0;
    [SerializeField] public int enemy_exp = 0;
    [SerializeField] public List<ItemSO> itemSO;
}