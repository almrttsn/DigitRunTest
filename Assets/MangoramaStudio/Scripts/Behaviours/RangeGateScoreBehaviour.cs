using MangoramaStudio.Scripts.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RangeGateScoreBehaviour : MonoBehaviour
{
    public static event Action<int> RangeUpdated;
    [SerializeField] private int _intialRangeScore;
    [SerializeField] private TextMesh _rangeText;
    private int _currentRange;

    private void Start()
    {
        _rangeText.text = ("Range: " + _intialRangeScore);
        _currentRange = _intialRangeScore;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            _currentRange++;
            _rangeText.text = ("Range: " + _currentRange);
            Destroy(other.gameObject);
        }
        else if(other.tag == "Player")
        {
            RangeUpdated?.Invoke(_currentRange);
            Destroy(gameObject);
        }
    }
}
