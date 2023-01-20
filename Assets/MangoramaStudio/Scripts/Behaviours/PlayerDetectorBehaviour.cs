using MangoramaStudio.Scripts.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDetectorBehaviour : MonoBehaviour
{
    private PlayerController _playerController;
    private int _moneyEarned;
    private int _fireRate;
    private int _range;

    public void Initialize(PlayerController playerController)
    {
        _playerController = playerController;
        MoneyBehaviour.PlayerEarnMoney += IsPlayerEarnMoney;
        FireRateGateScoreBehaviour.FireRateUpdated += IsFireRateUpdated;
        RangeGateScoreBehaviour.RangeUpdated += IsRangeUpdated;
    }

    private void IsRangeUpdated(int range)
    {
        _range = range;
        PlayerData.Range += _range;
    }

    private void IsFireRateUpdated(int fireRate)
    {
        _fireRate = fireRate;
        PlayerData.FireRate += _fireRate;
    }

    private void IsPlayerEarnMoney(int money)
    {
        _moneyEarned = money;
        PlayerData.Money += _moneyEarned;
        _playerController.PlayerMoneyDisplayBehaviour.PlayerMoneyDisplayText.text = PlayerData.Money.ToString();
        if(PlayerData.Money >= 0)
        {
            _playerController.PlayerMoneyDisplayBehaviour.PlayerMoneyDisplayText.color = Color.green; 
        }
        else
        {
            _playerController.PlayerMoneyDisplayBehaviour.PlayerMoneyDisplayText.color = Color.red;
        }
    }

    

    private void OnDestroy()
    {
        MoneyBehaviour.PlayerEarnMoney -= IsPlayerEarnMoney;
        FireRateGateScoreBehaviour.FireRateUpdated -= IsFireRateUpdated;
        RangeGateScoreBehaviour.RangeUpdated -= IsRangeUpdated;
    }
}
