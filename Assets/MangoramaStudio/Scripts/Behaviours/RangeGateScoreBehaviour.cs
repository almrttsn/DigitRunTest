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
        PlayerData.Range = _intialRangeScore;
        _rangeText.text = ("Range: " + PlayerData.Range);
        PlayerData.Range = _currentRange;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ObjectToFire")
        {
            _currentRange++;
            _rangeText.text = ("Range: " + _currentRange);
        }
    }
}
