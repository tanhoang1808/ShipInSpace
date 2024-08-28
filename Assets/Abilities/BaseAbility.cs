using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAbility : HoangMonoBehaviour
{
    [SerializeField] protected static BaseAbility instance;
    [SerializeField] public static BaseAbility Instance => instance;
    [SerializeField] protected Ability ability;
    [SerializeField] protected float cooldownTime;
    [SerializeField] public float CooldownTime => cooldownTime;
    [SerializeField] protected float activeTime;
    [SerializeField] public float ActiveTIme => activeTime;
    [SerializeField] protected AbilityCtrl abilityCtrl;
    [SerializeField] public AbilityCtrl AbilityCtrl => abilityCtrl;
    [SerializeField] public int LevelToUse;
    
    [SerializeField]
    public enum AbilityState
    {
        Ready,
        Active,
        Cooldown
    }

    protected override void Awake()
    {
        base.Awake();
        instance = this;
    }

    protected virtual void Start()
    {
        setLevelToUse();
    }


    AbilityState state = AbilityState.Ready;

    protected virtual void FixedUpdate()
    {
        this.SkillStateMachine();
    }

    protected abstract bool GetKeyDown();
    protected virtual void GetButtonDown()
    {

    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadAbility();
        this.LoadAbilityCtrl();
        
    }

   

    protected virtual void LoadAbility()
    {
        string resPath = "Ability" + "/" + transform.name;
        this.ability = Resources.Load<Ability>(resPath);
    }

    protected virtual void LoadAbilityCtrl()
    {
        this.abilityCtrl = GetComponentInParent<AbilityCtrl>();
    }

    protected virtual void Active()
    {

    }
    protected virtual void Active(Transform pos)
    {

    }


    protected virtual void InActive()
    {

    }

    protected virtual void SkillStateMachine()
    {
        switch (state)
        {
            case AbilityState.Ready:
                if (this.GetKeyDown())
                {
                    this.Active();
                    activeTime = ability.activeTime;
                    state = AbilityState.Active;


                }

                break;
            case AbilityState.Active:
                if (activeTime >= 0f)
                {
                    activeTime -= Time.deltaTime;

                }
                else
                {
                    state = AbilityState.Cooldown;
                    cooldownTime = ability.cooldownTime;
                }

                break;
            case AbilityState.Cooldown:
                if (cooldownTime > 0f)
                {
                    
                    cooldownTime -= Time.deltaTime;

                }
                else
                {
                    
                    state = AbilityState.Ready;
                    //this.InActive();
                }
                break;
        }
    }

    protected abstract void setLevelToUse();
    
}
