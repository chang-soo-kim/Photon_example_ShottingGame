using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using TMPro;

public class PlayerInfo : MonoBehaviourPun
{
    float PlayerMaxHP = 100f;
    float PlayerCurHP = 0f;
    bool playerDead = false;
    [SerializeField]
    Slider HPbar;

    private void Start()
    {
        PlayerCurHP = PlayerMaxHP;

        if (photonView.IsMine)
        {
            HPbar.gameObject.SetActive(false);
            return;
        }
        HPbar.value = PlayerCurHP / PlayerMaxHP;
    }
    private void Update()
    {
        if (photonView.IsMine || playerDead) return;
            HPbar.transform.LookAt(Camera.main.transform);
    }
    public void AttPlayer(float dmg) 
    {
        photonView.RPC("AttPlayerRPC",RpcTarget.All, dmg);
    }

    [PunRPC]
    public void AttPlayerRPC(float dmg)
    {
        if(PlayerCurHP > 0)
        {
          PlayerCurHP -= dmg;

            if (photonView.IsMine) return;
            HPbar.value = PlayerCurHP / PlayerMaxHP;
        }
        if(PlayerCurHP <= 0)
        {
            PhotonNetwork.Destroy(gameObject);
        }

    }
}
