using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerRotate : MonoBehaviourPun
{

    float rotateX, rotateY;
    [SerializeField]
    GameObject gun = null;

    // Update is called once per frame
    void Update()
    {

        if (photonView.IsMine == false )
        {
            return;
        }

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        rotateX += 200 * Time.deltaTime * mouseX;
        rotateY += 200 * Time.deltaTime * mouseY;

        rotateY = Mathf.Clamp(rotateY, -90, 90);
        //플레이어 좌우 회전
        transform.eulerAngles = new Vector3(0, rotateX, 0);
        Camera.main.transform.eulerAngles = new Vector3(-rotateY, Camera.main.transform.eulerAngles.y, Camera.main.transform.eulerAngles.z);
        gun.transform.eulerAngles = new Vector3(-rotateY, Camera.main.transform.eulerAngles.y, Camera.main.transform.eulerAngles.z);
    }
}
