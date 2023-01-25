using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBehaviour : MonoBehaviour
{
    public PlayerController PlayerController;
    public InteractObjectsController InteractObjectsController;
    public float WinPanelDelayTime => _winPanelDelayTime;
    public float LosePanelDelayTime => _losePanelDelayTime;

    [SerializeField] private float _winPanelDelayTime;
    [SerializeField] private float _losePanelDelayTime;

    private GameManager _gameManager;
    private bool _isLevelEnded;

    public void Initialize(GameManager gameManager, bool isRestart = false)
    {
        _gameManager = gameManager;
        //PlayerPrefs.DeleteAll();
        PlayerController.Initialize(gameManager);
        InteractObjectsController.Initialize(gameManager);
        foreach (var door in InteractObjectsController.DoorBehaviourList)
        {
            door.MoneyIsNotEnough += IsMoneyNotEnough;
        }
        foreach (var door in InteractObjectsController.DoorBehaviourList)
        {
            door.AllDoorsOpened += AreAllDoorsOpened;
        }

        InteractObjectsController.AllDoorsOpened += AreAllDoorsOpened;
        
        if (!isRestart)
        {
            _gameManager.EventManager.StartLevel();
        }
    }

    private void AreAllDoorsOpened(int playerMoney)
    {
        LevelCompleted();
        Debug.Log("Level completed, your money is:" + playerMoney + "$");
    }

    private void IsMoneyNotEnough(int playerMoney)
    {
        LevelFailed();
        Debug.Log("Your money is not enough, you have: " + playerMoney + "$");
    }

    private void Update()
    {
        if (Input.GetKeyDown("c"))
        {
            LevelCompleted();
        }

        if (Input.GetKeyDown("f"))
        {
            LevelFailed();
        }
    }

    private void OnDestroy()
    {
        foreach (var door in InteractObjectsController.DoorBehaviourList)
        {
            door.MoneyIsNotEnough -= IsMoneyNotEnough;
        }
        InteractObjectsController.AllDoorsOpened -= AreAllDoorsOpened;
    }

    private void LevelCompleted()
    {
        if (_isLevelEnded) return;

        _gameManager.EventManager.LevelCompleted();
        InputController.IsInputDeactivated = true;
        _isLevelEnded = true;
    }

    private void LevelFailed()
    {
        if (_isLevelEnded) return;

        _gameManager.EventManager.LevelFailed();
        InputController.IsInputDeactivated = true;
        _isLevelEnded = true;
    }

    
}
