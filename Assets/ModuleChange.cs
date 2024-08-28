using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ModuleChange : HoangMonoBehaviour
{
    [SerializeField] public ShipModuleCtrl shipModuleCtrl;

    [SerializeField] public delegate void ModuleNotify(string name);
    [SerializeField] public static event ModuleNotify moduleNotify;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadModuleCtrl();
        
    }

    protected virtual void LoadModuleCtrl()
    {
        this.shipModuleCtrl = Transform.FindAnyObjectByType<ShipModuleCtrl>();
    }

   
    protected override void Awake()
    {
        Inventory.notify += ChangeModule;
    }

    protected virtual void ChangeModule(ItemCode itemCode)
    {
        FindModuleToChange(itemCode.ToString());
    }

    protected virtual void FindModuleToChange(string name)
    {
        foreach(Transform module in shipModuleCtrl.modules)
        {
            if (module.name == name)
            {
                
                if(ModuleIsActiving(module))
                {
                   
                    
                }
                
                ActiveModule(module);
                moduleNotify(module.name);

            }
            else if(module.name != name && ModuleIsActiving(module))
            {
                DisableModule(module);
                
            }
            
        }
    }

    protected virtual void ActiveModule(Transform module)
    {
        module.gameObject.SetActive(true);
    }

    protected virtual void DisableModule(Transform module)
    {
        module.gameObject.SetActive(false);
    }

    protected virtual bool ModuleIsActiving(Transform name)
    {
        foreach(Transform module in ShipModuleCtrl.Instance.transform)
        {
            if(module.gameObject.activeInHierarchy && module.name == name.name)
            {
                return true;
                
            }
           
        }
        return false;
    }

}
