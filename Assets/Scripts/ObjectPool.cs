using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class ObjectPool : MonoBehaviourPunCallbacks//,IPunPrefabPool
{
    //private ObjectPool() { }

    //private static ObjectPool inst = null;
    //public static ObjectPool Inst
    //{
    //    get
    //    {
    //        if(inst == null)
    //        {
    //            inst = GameObject.FindObjectOfType<ObjectPool>();
    //            if(inst == null)
    //            {
    //                inst = new GameObject("ObjectPool").AddComponent<ObjectPool>();
    //            }
    //        }
    //        return inst;
    //    }
    //}


    //Queue<GameObject> bulletPool = new Queue<GameObject>();
    
    //public void Destroy(GameObject gameObject)
    //{
    //    if (photonView.IsMine)
    //    {

    //    PhotonNetwork.Destroy(gameObject);
    //        gameObject.SetActive(false);
    //    }
    //}

    //public GameObject Instantiate(string prefabId, Vector3 position, Quaternion rotation)
    //{
    //    GameObject inst = null;

    //        inst = PhotonNetwork.Instantiate(prefabId, position, rotation);

    //    return inst;
    //}


}
