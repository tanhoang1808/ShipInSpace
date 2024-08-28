using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ability",menuName = "AbilitySO/Ability")]
public class Ability : ScriptableObject
{
    [SerializeField] public abilityCode abilityCode = abilityCode.NoCode;
    [SerializeField] public float cooldownTime;
    [SerializeField] public float activeTime;
    [SerializeField] public int levelToUse;
    [SerializeField] public ShipCode shipToUse;
    
}
