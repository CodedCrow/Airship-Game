using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyscript : MonoBehaviour
{
    [SerializeField] private float Health;



    public void Damage(float Value)
    {
        Health -= Value;
        if(Health <= 0)
        {
            Destroy(gameObject);
            return;
        }
    }
}
