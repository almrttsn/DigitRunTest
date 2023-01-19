using MangoramaStudio.Scripts.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RangeGateScoreBehaviour : MonoBehaviour
{
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
        }
        else if(other.tag == "Player")
        {
            PlayerData.Range += _currentRange;
            Destroy(gameObject);
        }
    }
}
