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
        PlayerData.FireRate = _initialFireRateScore;
        _fireRateText.text = ("Fire rate: " + PlayerData.FireRate);
        PlayerData.FireRate = _currentFireRate;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ObjectToFire")
        {
            _currentFireRate++;
            _fireRateText.text = ("Fire rate: " + _currentFireRate);
        }
    }
}
