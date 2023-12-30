using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class NetworkStartUI : MonoBehaviour
{
    [SerializeField] Button HostButton;
    [SerializeField] Button ClientButton;


    private void Start()
    {
        HostButton.onClick.AddListener(startHost);
        ClientButton.onClick.AddListener(startClient);
    }

    void startHost()
    {
        NetworkManager.Singleton.StartHost();
    }

    void startClient()
    {
        NetworkManager.Singleton.StartClient();
    }
}
