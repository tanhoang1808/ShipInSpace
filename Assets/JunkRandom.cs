//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class JunkRandom : HoangMonoBehaviour
//{
//    [Header("Junk Random")]
    
//    [SerializeField] public List<Transform> posList;

//    [SerializeField] protected JunkCtrl junkCtrl;
//    public JunkCtrl JunkCtrl => junkCtrl;

   
//    protected override void LoadComponent()
//    {
//        base.LoadComponent();
        
//        this.LoadJunkCtrl();
//    }
//    protected virtual void Start()
//    {
//        this.JunkSpawning();
//    }



//    protected virtual void LoadJunkCtrl()
//    {
//        if (this.junkCtrl != null) return;
//        junkCtrl = Transform.FindObjectOfType<JunkCtrl>();
//    }

//    protected virtual void JunkSpawning()
//    {
//        if(JunkCtrl.Instance.transform)
//        {
//            Transform randomPos = JunkCtrl.Instance.SpawnPoint.GetRandom();
//            Vector3 pos = randomPos.transform.position;
//            Quaternion rot = randomPos.transform.rotation;
//            Transform prefab = JunkCtrl.JunkSpawner.Spawn(JunkSpawner.AsteroidOne, pos, rot);

//            prefab.gameObject.SetActive(true);
//            Invoke(nameof(JunkSpawning), 1f);
//        }

//    }

//}
