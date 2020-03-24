using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Shoot : MonoBehaviourPun, IPunObservable
{
    public Camera cam;
    public GameObject arrowPrefab;
    public Transform arrowSpawn;
    public float shootForce = 20f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    public void Update()
    {
        if (!photonView.IsMine) return;
         shoot();
    }
    public void shoot()
    {
        photonView.RPC("RpcShoot", RpcTarget.All);
    }


    [PunRPC]
    public void RpcShoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject go = Instantiate(arrowPrefab, arrowSpawn.position, Quaternion.identity);
            Rigidbody rb = go.GetComponent<Rigidbody>();
            rb.velocity = cam.transform.forward * shootForce;
        }
    }
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
    }
}
