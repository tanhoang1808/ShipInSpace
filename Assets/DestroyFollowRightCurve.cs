using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFollowRightCurve : HoangMonoBehaviour
{
    [Header("Route Control")]
    [SerializeField] protected Transform[] routes;
    

    [SerializeField] protected int routeToGo;

    [SerializeField] protected float tParam;

    [SerializeField] protected Vector3 objectPosition;

    [SerializeField] protected float speedModifier;

    [SerializeField] protected bool coroutineAllowed;

    // Start is called before the first frame update
    protected override void OnEnable()
    {
        base.OnEnable();
        routeToGo = 0;
        
        tParam = 0f;
        speedModifier = 1.2f;
        coroutineAllowed = true;
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        
    }


    // Update is called once per frame
    void Update()
    {
        if (coroutineAllowed)
        {
            StartCoroutine(GoByTheRoute(routeToGo));
            
        }
    }

    private IEnumerator GoByTheRoute(int routeNum)
    {
        //routeNum = Random.Range(0, 2);
        coroutineAllowed = false;
        
        Vector3 p0 = routes[routeNum].GetChild(0).position;
        Vector3 p1 = routes[routeNum].GetChild(1).position;
        Vector3 p2 = routes[routeNum].GetChild(2).position;
        Vector3 p3 = routes[routeNum].GetChild(3).position;
        
        while (tParam < 1)
        {
            tParam += Time.deltaTime * speedModifier;

            objectPosition = Mathf.Pow(1 - tParam, 3) * p0 + 3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 + 3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 + Mathf.Pow(tParam, 3) * p3;

            transform.parent.position = objectPosition;
            yield return new WaitForEndOfFrame();
        }

        tParam = 0;
        speedModifier*=0.90f;
        coroutineAllowed = true;
        routeToGo += 1;
        Debug.Log(routeToGo);

        if (routeToGo > routes.Length - 1)
        {
            routeToGo = 0;
        }



    }

   

}
