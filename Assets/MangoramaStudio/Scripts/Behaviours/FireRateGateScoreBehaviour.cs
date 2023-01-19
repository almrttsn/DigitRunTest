using MangoramaStudio.Scripts.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireRateGateScoreBehaviour : MonoBehaviour
{
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
        }
        else if (other.tag == "Player")
        {
            PlayerData.FireRate += _currentFireRate; ;
        }
    }
}
