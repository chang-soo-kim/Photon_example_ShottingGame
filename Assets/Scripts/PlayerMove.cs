using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class PlayerMove : MonoBehaviourPun
{


    void Update()
    {
        if (photonView.IsMine == false) return;

        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(inputX,0f, inputY);
        //dir = Camera.main.transform.TransformDirection(dir);

        transform.Translate(dir * Time.deltaTime * 5,Space.Self);
        
    }
}
