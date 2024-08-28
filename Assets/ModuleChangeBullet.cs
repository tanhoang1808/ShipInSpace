using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleChangeBullet : HoangMonoBehaviour
{
    [SerializeField] public BulletModuleCtrl bulletModuleCtrl;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadModuleCtrl();

    }

    protected virtual void LoadModuleCtrl()
    {
        this.bulletModuleCtrl = GetComponent<BulletModuleCtrl>();
    }

    //protected override void Awake()
    //{
    //    ChangeModule(bulletModuleCtrl.modules[0].name);
    //}

    protected override void OnEnable()
    {
        
        ModuleChange.moduleNotify += ChangeModule;
        

    }
    


    protected virtual void ChangeModule(string name)
    {
        
        FindModuleToChange(name);
        
    }

    protected virtual void FindModuleToChange(string name)
    {
        
        foreach (Transform module in bulletModuleCtrl.modules)
        {
            if (module.name == name)
            {

                if (ModuleIsActiving(module))
                {
                    
                    
                }

                ActiveModule(module);
                

            }
            else if (module.name != name && ModuleIsActiving(module))
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
        foreach (Transform module in ShipModuleCtrl.Instance.transform)
        {
            if (module.gameObject.activeInHierarchy && module.name == name.name)
            {
                return true;

            }

        }
        return false;
    }

}
