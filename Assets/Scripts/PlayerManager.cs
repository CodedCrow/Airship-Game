using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : NetworkBehaviour
{
    [SerializeField] private ShipMaster Ship;
    [SerializeField] private List<InputScript> Players = new List<InputScript>(); 
    [SerializeField] private int[] SelectedJob = new int[4];
    [SerializeField] private UIManager UIs;

    public List<InputScript> GetPlayers()
    {
        return Players;
    }

    public void NewPlayerAdded(InputScript player)
    {
        Players.Add(player);
        //update the player role, bypassing the set default
        SetRole(Players.Count - 1);
    }

    public void NewPlayerAdded(PlayerInput player)
    {
        Players.Add(player.GetComponent<InputScript>());

        //update the player role, bypassing the set default
        SetRole(Players.Count - 1);
    }


    public void ChangeRoleUp(int playerSlot)
    {
        SelectedJob[playerSlot]++;
        if (SelectedJob[playerSlot] >= 2)
        {
            SelectedJob[playerSlot] = 0;
        }
        SetRole(playerSlot);
        UIs.UpdateRoles();
    }

    private void SetRole(int playerSlot)
    {
        switch (SelectedJob[playerSlot])
        {
            case 0:
                Players[playerSlot].PlayerJob = InputScript.PlayerJobEnum.Pilot;
                break;
            case 1:
                Players[playerSlot].PlayerJob = InputScript.PlayerJobEnum.Gunner;
                break;
        }

    }

    public void OnGameStart()
    {
        for (int i = 0; i < Players.Count; i++)
        {
            Ship.players[i] = Players[i];
        }
        Ship.Countplayers();
    }
}
