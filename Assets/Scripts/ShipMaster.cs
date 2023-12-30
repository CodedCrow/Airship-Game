using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMaster : MonoBehaviour
{
    [SerializeField] private GunScript[] Guns;
    public InputScript[] players;
    [SerializeField] private Vector2 TotalMove;
    [SerializeField] private List<InputScript> Gunners = new List<InputScript>();
    [SerializeField] private List<InputScript> Pilots = new List<InputScript>();
    [SerializeField] private float Speed = 0.5f;

    public void Countplayers()
    {

        for (int i = 0; i < players.Length; i++)
        {
            if (players[i] != null)
            {

                if (players[i].GetPlayerJob() == InputScript.PlayerJobEnum.Pilot && !Pilots.Contains(players[i]))
                {
                    Pilots.Add(players[i]);
                }
                else if (players[i].GetPlayerJob() == InputScript.PlayerJobEnum.Gunner && !Gunners.Contains(players[i]))
                {
                    Gunners.Add(players[i]);
                }
            }
        }
    }

void Update()
    {
        TotalMove = Vector2.zero;

        //check every player in the gunner box
        for (int i = 0; i < Gunners.Count; i++)
        {
            Guns[i].Aim = Gunners[i].Input;
            Guns[i].openFire = Gunners[i].ButtonPressbool;
        }
        //move guns based on inputs

        //check every player in the pilot box
        for (int i = 0; i < Pilots.Count; i++)
        {
            TotalMove += Pilots[i].Input;
        }
        //Add up their values and move the ship based on that input


        transform.Translate(Speed * Time.deltaTime * TotalMove);
    }


}
