using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTriggerBehaviour : MonoBehaviour
{
    public static event Action PlayerReachedEndTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("EndTrigger");
            PlayerReachedEndTrigger?.Invoke();
        }
    }
}
