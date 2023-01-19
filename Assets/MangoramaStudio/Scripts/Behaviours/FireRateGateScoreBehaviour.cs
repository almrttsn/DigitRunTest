using MangoramaStudio.Scripts.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireRateGateScoreBehaviour : MonoBehaviour
{
    public static event Action<int> FireRateUpdated;
    [SerializeField] private int _initialFireRateScore;
    [SerializeField] private TextMesh _fireRateText;
    private int _currentFireRate;

    private void Start()
    {
        _fireRateText.text = ("Fire rate: " + _initialFireRateScore);
        _currentFireRate = _initialFireRateScore;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            _currentFireRate++;
            _fireRateText.text = ("Fire rate: " + _currentFireRate);
            Destroy(other.gameObject);
        }
        else if (other.tag == "Player")
        {
            FireRateUpdated?.Invoke(_currentFireRate);
            Destroy(gameObject);
        }
    }
}
