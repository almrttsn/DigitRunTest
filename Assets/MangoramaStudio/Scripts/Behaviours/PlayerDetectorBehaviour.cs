using MangoramaStudio.Scripts.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDetectorBehaviour : MonoBehaviour
{
    private int _moneyEarned;
    private int _fireRate;
    private int _range;

    private void Start()
    {
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
    }

    private void OnDestroy()
    {
        MoneyBehaviour.PlayerEarnMoney -= IsPlayerEarnMoney;
        FireRateGateScoreBehaviour.FireRateUpdated -= IsFireRateUpdated;
        RangeGateScoreBehaviour.RangeUpdated -= IsRangeUpdated;
    }
}
