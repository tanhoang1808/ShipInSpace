using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawner : Spawner
{
    [SerializeField] protected Vector3 startPosition;
    protected float repeatWidth;
    //[SerializeField] protected Vector3 offset = new Vector3(0,65,0);
    //[SerializeField] protected float SpawnPos = -4f;
    //[SerializeField] protected float width;
    protected virtual void Start()
    {
        ActivePrefab();
        startPosition = transform.position; //new Vector3(0.0f,transform.parent.position.y);
        repeatWidth = GetComponent<BoxCollider>().size.y / 2;
        
    }

    

    protected virtual void Update()
    {
        this.Spawning();
    }


    protected virtual void ActivePrefab()
    {
        foreach (Transform prefab in prefabs)
        {
            prefab.gameObject.SetActive(true);
        }
    }

    protected virtual void Spawning()
    {
        if (transform.position.y <= startPosition.y - repeatWidth) ;
        {
            transform.position = startPosition;
            //this.Spawn(prefabs[0], startPosition + new Vector3(0.0f,60f), Quaternion.identity);
            
            //return;
        }
    }

}
