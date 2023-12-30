using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{

        public static EventManager current;
        public Action OnPlayerSpawn;

        void Awake()
        {
            current = this;
        }

        public void PlayerSpawn()
        {
            OnPlayerSpawn?.Invoke();
        }


}
