using DG.Tweening;
using MangoramaStudio.Scripts.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    public GameObject DoorPivot => _doorPivot;
    public event Action<int> MoneyIsNotEnough;
    public event Action<int> AllDoorsOpened;
    public bool IsThisLastDoor;
    [SerializeField] private bool _doorOpeningToRight;
    [SerializeField] private GameObject _doorPivot;
    [SerializeField] private int _initialDoorAmount;
    [SerializeField] private TextMesh _doorText;
    private PlayerMovementBehaviour _playerMovementBehaviour;
    private InteractObjectsController _interactObjectsController;

    private bool _doorTriggeredOnce;

    public void Initialize(InteractObjectsController interactObjectsController)
    {
        _interactObjectsController = interactObjectsController;
        _doorText.text = _initialDoorAmount.ToString();
        _playerMovementBehaviour = FindObjectOfType<PlayerMovementBehaviour>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && PlayerData.Money > _initialDoorAmount)
        {
            if (_doorTriggeredOnce == false && _doorOpeningToRight == false)
            {
                _doorPivot.transform.DORotate(new Vector3(0, -90f, 0), 1f);
                if(IsThisLastDoor == true)
                {
                    AllDoorsOpened?.Invoke(PlayerData.Money);
                }
            }
            else if(_doorTriggeredOnce == false && _doorOpeningToRight == true)
            {
                _doorPivot.transform.DORotate(new Vector3(0, 90f, 0), 1f);
                if (IsThisLastDoor == true)
                {
                    AllDoorsOpened?.Invoke(PlayerData.Money);
                }
            }
            _doorTriggeredOnce = true;
        }
        else if(other.tag == "Player" && PlayerData.Money < _initialDoorAmount)
        {
            _playerMovementBehaviour.PlayerMovementRestricted = true;
            MoneyIsNotEnough?.Invoke(PlayerData.Money);
        }
    }

}
