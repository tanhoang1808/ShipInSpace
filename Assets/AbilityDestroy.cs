using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityDestroy : BaseAbility
{
    Transform destroy;
    abilityCode code;
    [SerializeField] protected Vector2 gizmosPosition;
    [SerializeField] protected PointCurveFindEnemy[] pointCurveFindEnemy;
    [SerializeField] protected List<Transform> rightPoints = new List<Transform>();
    [SerializeField] protected List<Transform> leftPoints = new List<Transform>();
    [SerializeField] protected int missile = 0;
    [SerializeField] protected int maxMissle = 11;
    [SerializeField] public static int count = 0;
    protected override void Start()
    {
        base.Start();
        this.setLevelToUse();
        missile = maxMissle;
    }
    


    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCurvePoints();
        this.LoadPointCurveFindEnemy();
    }

    protected virtual void Update()
    {
        Transform nearstEnemyPos = this.pointCurveFindEnemy[0].CheckNearstEnemy();
        

    }



    protected virtual void LoadCurvePoints()
    {
        if (rightPoints.Count >=4 ) return;
        foreach (Transform point in transform.GetChild(0).transform)
        {
            rightPoints.Add(point);
        }

        if (leftPoints.Count >= 4) return;
        foreach (Transform point in transform.GetChild(1).transform)
        {
            leftPoints.Add(point);
        }

    }
 
    protected override void Active()
    {
        StartCoroutine(RightMissleAppear());

    }

    protected IEnumerator RightMissleAppear()
    {
        Debug.Log("RightMissleAppear Started");

        while (missile < 20)
        {
            Debug.Log("Missile Count: " + missile);

            Transform nearstEnemyPos = this.pointCurveFindEnemy[0].CheckNearstEnemy();
            if (nearstEnemyPos == null) yield break;

            this.rightPoints[3].position = nearstEnemyPos.position;
            code = abilityCode.Destroy;
            destroy = this.abilityCtrl.ProjectileSpawner.Spawn(code.ToString(), rightPoints[0].position, rightPoints[0].rotation);
            destroy.transform.GetComponent<DestroyCtrl>().SetShooter(transform.parent.parent);
           
            //AudioCtrl.Instance.FireProjectileFX();
            destroy.gameObject.SetActive(true);
            missile++;
            yield return new WaitForSeconds(0.04f);
        }
        Debug.Log("Missile Count: " + missile);
        Debug.Log("RightMissleAppear Ended");
    }
    //protected IEnumerator LeftMissleAppear()
    //{

    //    if (missile >= 20) StopAllCoroutines();
    //    while (missile < 20)
    //    {
    //        Transform nearstEnemyPos = this.pointCurveFindEnemy[1].CheckNearstEnemy();
    //        if (nearstEnemyPos == null) yield break;
    //        this.leftPoints[3].position = nearstEnemyPos.position;
    //        code = abilityCode.Destroy;
    //        destroy = this.abilityCtrl.ProjectileSpawner.Spawn(code.ToString(), leftPoints[0].position, leftPoints[0].rotation);
    //        destroy.transform.GetComponent<DestroyCtrl>().SetShooter(transform.parent.parent);
    //        //AudioCtrl.Instance.FireProjectileFX();
    //        destroy.gameObject.SetActive(true);
    //        missile++;
    //        yield return new WaitForSeconds(0.04f);

    //        StartCoroutine(RightMissleAppear());
    //    }

    //}



    protected override bool GetKeyDown()
    {
        
        if ((abilityCtrl.InputManager.PressC()) && abilityCtrl.shipCtrl.level >= this.LevelToUse)
        {
            
            return true;
        }
        else if(ButtonUICtrl.Instance.DestroyButton.GetComponent<BtnDestroy>().DestroyClicked && abilityCtrl.shipCtrl.level >= this.LevelToUse)
        {
            ButtonUICtrl.Instance.DestroyButton.GetComponent<BtnDestroy>().DestroyClicked = false;

            return true;
        }
        return false;
    }

    private void OnDrawGizmos()
    {
        for (float t = 0; t <= 1; t += 0.05f)
        {
            gizmosPosition = Mathf.Pow(1 - t, 3) * rightPoints[0].position + 3 * Mathf.Pow(1 - t, 2) * t * rightPoints[1].position + 3
                * (1 - t) * Mathf.Pow(t, 2) * rightPoints[2].position + Mathf.Pow(t, 3) * rightPoints[3].position;

            Gizmos.DrawSphere(gizmosPosition, 0.25f);
        }

        Gizmos.DrawLine(new Vector2(rightPoints[0].position.x, rightPoints[0].position.y),
            new Vector2(rightPoints[1].position.x, rightPoints[1].position.y));
        Gizmos.DrawLine(new Vector2(rightPoints[2].position.x, rightPoints[2].position.y),
            new Vector2(rightPoints[3].position.x, rightPoints[3].position.y));

        for (float t = 0; t <= 1; t += 0.05f)
        {
            gizmosPosition = Mathf.Pow(1 - t, 3) * leftPoints[0].position + 3 * Mathf.Pow(1 - t, 2) * t * leftPoints[1].position + 3
                * (1 - t) * Mathf.Pow(t, 2) * leftPoints[2].position + Mathf.Pow(t, 3) * leftPoints[3].position;

            Gizmos.DrawSphere(gizmosPosition, 0.25f);
        }

        Gizmos.DrawLine(new Vector2(leftPoints[0].position.x, leftPoints[0].position.y),
            new Vector2(leftPoints[1].position.x, leftPoints[1].position.y));
        Gizmos.DrawLine(new Vector2(leftPoints[2].position.x, leftPoints[2].position.y),
            new Vector2(leftPoints[3].position.x, leftPoints[3].position.y));
    }

    protected virtual void LoadPointCurveFindEnemy()
    {
        this.pointCurveFindEnemy = GetComponentsInChildren<PointCurveFindEnemy>();
    }

    protected override void setLevelToUse()
    {
        this.LevelToUse = this.ability.levelToUse;
    }
}