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
    private MeshRenderer _meshRenderer;

    private void Start()
    {
        _rangeText.text = ("Range:" + _intialRangeScore + "$");
        _meshRenderer = GetComponent<MeshRenderer>();
        if(_intialRangeScore >= 0)
        {
            _meshRenderer.material.color = Color.green;
        }
        else
        {
            _meshRenderer.material.color = Color.red;
        }
        _currentRange = _intialRangeScore;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            _currentRange++;
            _rangeText.text = ("Range:" + _currentRange + "$");
            Destroy(other.gameObject);
            if (_currentRange >= 0)
            {
                _meshRenderer.material.color = Color.green;
            }
            else
            {
                _meshRenderer.material.color = Color.red;
            }
        }
        else if(other.tag == "Player")
        {
            RangeUpdated?.Invoke(_currentRange);
            Destroy(gameObject);
        }
    }
}
