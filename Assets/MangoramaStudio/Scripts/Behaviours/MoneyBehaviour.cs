using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyBehaviour : MonoBehaviour
{
    public static event Action<int> PlayerEarnMoney;
    [SerializeField] private int _initialMoneyAmount;
    [SerializeField] private TextMesh _moneyText;
    private int _currentMoneyAmount;

    private void Start()
    {
        _moneyText.text = (_initialMoneyAmount.ToString());
        _currentMoneyAmount = _initialMoneyAmount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            _currentMoneyAmount++;
            _moneyText.text = ( _currentMoneyAmount.ToString());
            Destroy(other.gameObject);
        }
        else if (other.tag == "Player")
        {
            PlayerEarnMoney?.Invoke(_currentMoneyAmount);
            Debug.Log("Money amount from event: " + _currentMoneyAmount);
            Destroy(gameObject);
        }
    }
}
