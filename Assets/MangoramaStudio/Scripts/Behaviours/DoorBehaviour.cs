using DG.Tweening;
using MangoramaStudio.Scripts.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject _doorPivot;
    [SerializeField] private int _initialDoorAmount;
    [SerializeField] private TextMesh _doorText;
    [SerializeField] private PlayerMovementBehaviour _playerMovementBehaviour;

    private bool _doorTriggeredOnce;

    public void Initialize(InteractObjectsController interactObjectsController)
    {
        _doorText.text = _initialDoorAmount.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && PlayerData.Money > _initialDoorAmount)
        {
            if (_doorTriggeredOnce == false)
            {
                _doorPivot.transform.DORotate(new Vector3(0, -90f, 0), 1f);
            }
            _doorTriggeredOnce = true;
        }
        else if(other.tag == "Player" && PlayerData.Money < _initialDoorAmount)
        {
            _playerMovementBehaviour.PlayerMovementRestricted = true;
            Debug.Log("Money is not enough to open this gate");
        }
    }

}
