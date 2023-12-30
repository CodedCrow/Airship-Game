using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputScript : MonoBehaviour
{
    public Vector2 Input;
    public float ButtonPressFloat;
    public bool ButtonPressbool;
    public PlayerJobEnum PlayerJob;
    public NetworkObject self;

    public enum PlayerJobEnum
    {
        Pilot,
        Gunner
    }

    public void OnMove(InputValue value)
    {
        Input = value.Get<Vector2>();
    }

    public void OnFire(InputValue value)
    {
        ButtonPressFloat = value.Get<float>();
    }

    public PlayerJobEnum GetPlayerJob()
    {
        return PlayerJob;
    }

    private void Update()
    {
        ButtonPressbool = (ButtonPressFloat >= 0.5);
    }

    private void Awake()
    {
        GameObject playermother = GameObject.Find("PlayerMother");
        playermother.GetComponent<PlayerManager>().NewPlayerAdded(this);
    }
}
