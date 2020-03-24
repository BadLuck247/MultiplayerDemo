using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Player : MonoBehaviourPun
{
    public static void RefreshInstance(ref Player player, Player Prefab)
    {
        var position = Vector3.zero + new Vector3(0, 1, 0);
        var rotation = Quaternion.identity;
        if (player != null)
        {
            position = player.transform.position;
            rotation = player.transform.rotation;
            PhotonNetwork.Destroy(player.gameObject);
        }

        player = PhotonNetwork.Instantiate(Prefab.gameObject.name, position, rotation).GetComponent<Player>();
    }
}
