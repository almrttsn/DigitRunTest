using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{

    [SerializeField] private GameObject _doorPivot;
    private bool _doorTriggeredOnce;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (_doorTriggeredOnce == false)
            {
                _doorPivot.transform.DORotate(new Vector3(0, -90f, 0), 1f);
            }
            _doorTriggeredOnce = true;
        }
    }
}
