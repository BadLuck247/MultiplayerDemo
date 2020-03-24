using UnityEngine;
using System.Collections;
using Photon.Pun;
using UnityEngine.SceneManagement;
using Photon.Realtime;
    public class Manager : MonoBehaviourPunCallbacks
    {
        [Header("UC Game Manager")]

        public Player PlayerPrefab;

        [HideInInspector]
        public Player LocalPlayer;

        private void Awake()
        {
            if (!PhotonNetwork.IsConnected)
            {
                return;
            }
        }

        // Use this for initialization
        void Start()
        {
            Player.RefreshInstance(ref LocalPlayer, PlayerPrefab);
        }

        // Update is called once per frame
        void Update()
        {

        }

        public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
        {
           Player.RefreshInstance(ref LocalPlayer, PlayerPrefab);
        }
    }
