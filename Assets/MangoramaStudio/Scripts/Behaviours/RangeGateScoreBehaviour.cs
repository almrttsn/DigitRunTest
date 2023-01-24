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

    public void Initialize(InteractObjectsController interactObjectsController)
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        if (_intialRangeScore >= 0)
        {
            _rangeText.text = ("+" + _intialRangeScore + "$");
            _meshRenderer.material.color = Color.green;
        }
        else
        {
            _rangeText.text = (_intialRangeScore + "$");
            _meshRenderer.material.color = Color.red;
        }
        _currentRange = _intialRangeScore;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            _currentRange++;
            Destroy(other.gameObject);
            if (_currentRange >= 0)
            {
                _rangeText.text = ("+" + _currentRange + "$");
                _meshRenderer.material.color = Color.green;
            }
            else
            {
                _rangeText.text = (_currentRange + "$");
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
