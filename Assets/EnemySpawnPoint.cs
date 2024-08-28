using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoint : HoangMonoBehaviour
{

    [SerializeField] protected List<Transform> Points;
    [SerializeField] protected int index;


    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSpawnPoint();
    }

    protected virtual void LoadSpawnPoint()
    {

        foreach (Transform point in transform)
        {
            if (Points.Count >= 5) return;
            Points.Add(point);
        }
    }

    public virtual Transform GetWave(int i)
    {
        return Points[i-1];
    }

    public virtual Transform GetRandom()
    {
        index = Random.Range(0, Points.Count);
        return Points[index];
    }
}
