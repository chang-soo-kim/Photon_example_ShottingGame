using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Bullet : MonoBehaviourPun
{
    float speed = 20f;
    float time = 0f;
    float dmg = 10f;
    bool enter = false;



    void Update()
    {
        if (photonView.IsMine == false) return;

        transform.Translate(Vector3.forward * Time.deltaTime * speed,Space.Self);
        time += Time.deltaTime;
        if (time > 2f)
        {
            PhotonNetwork.Destroy(gameObject);
            time = 0f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (photonView.IsMine == false) return;
       
        if (collision.gameObject.tag == "Player" && enter == false)
        {
            enter = true;
            collision.gameObject.GetComponent<PlayerInfo>().AttPlayer(dmg);
            PhotonNetwork.Destroy(gameObject);
        }
    }

 


}
