using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpawner : Spawner
{
    [SerializeField] protected float width = 316f;

    protected override void Update()
    {
        
        this.BackgrounParallex();
    }

    

    public virtual void BackgrounParallex()
    {
        if(this.prefabs[0].localPosition.y <-width)
        {
            Vector3 RepeatPos = new Vector3(this.transform.position.x, this.width);
            Transform obj = Spawn(this.prefabs[0],RepeatPos, transform.rotation);
            obj.gameObject.SetActive(true);
        }

    }
   
}
