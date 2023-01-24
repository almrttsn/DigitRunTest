using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTriggerBehaviour : MonoBehaviour
{
    public static event Action PlayerReachedEndTrigger;

    public void Initialize(InteractObjectsController interactObjectsController)
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("EndTrigger");
            PlayerReachedEndTrigger?.Invoke();
        }
    }

}
