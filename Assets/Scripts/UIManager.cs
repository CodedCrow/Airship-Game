using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private PlayerManager playerManager;
    [SerializeField] private TMP_Text[] Text = new TMP_Text[4];



    void Start()
    {
        playerManager = gameObject.GetComponent<PlayerManager>();
    }

    public void UpdateRoles()
    {
        List<InputScript> Players = playerManager.GetPlayers();
        for (int i = 0; i < Text.Length; i++)
        {
            if (i < Players.Count)
            {
                Text[i].text = Players[i].PlayerJob.ToString();
            }
            else
            {
                Text[i].text = "Player not found";
            }
        }
    }
}
/*/
public class UiNetwork : NetworkBehaviour
{
    public NetworkVariable<int> playerJob = new NetworkVariable<int>(0, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        playerJob.OnValueChanged += (int previousValue, int NewValue) =>
        {
        }
    }
}
/*/