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
    private MeshRenderer _meshRenderer;

    public void Initialize(InteractObjectsController interactObjectsController)
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        if (_initialFireRateScore >= 0)
        {
            _fireRateText.text = ("+" + _initialFireRateScore + "$");
            _meshRenderer.material.color = Color.green;
        }
        else
        {
            _fireRateText.text = (_initialFireRateScore + "$");
            _meshRenderer.material.color = Color.red;
        }
        _currentFireRate = _initialFireRateScore;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            _currentFireRate++;
            Destroy(other.gameObject);
            if (_currentFireRate >= 0)
            {
                _fireRateText.text = ("+" + _currentFireRate + "$");
                _meshRenderer.material.color = Color.green;
            }
            else
            {
                _fireRateText.text = (_currentFireRate + "$");
                _meshRenderer.material.color = Color.red;
            }
        }
        else if (other.tag == "Player")
        {
            FireRateUpdated?.Invoke(_currentFireRate);
            Destroy(gameObject);
        }
    }
}
