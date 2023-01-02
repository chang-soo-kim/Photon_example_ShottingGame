using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class BulletSpawner : MonoBehaviourPun
{

    void Update()
    {
        if (photonView.IsMine == false ) { return; }
        
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log(transform.rotation);
            PhotonNetwork.Instantiate("Bullet", transform.position, transform.rotation);
        }
    }
}
