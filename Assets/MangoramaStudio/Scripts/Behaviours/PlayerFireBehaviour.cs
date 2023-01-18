using DG.Tweening;
using MangoramaStudio.Scripts.Data;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireBehaviour : MonoBehaviour
{
    [SerializeField] private Transform _barrelPoint;
    [SerializeField] private GameObject _objectToFirePrefab;
    [SerializeField] private float _speedFactor;
    [SerializeField] private float _arriveTimeOfThrow;
    [SerializeField] private float _destroyTimeOfObjectToFire;

    private void Start()
    {
        StartCoroutine(FireRateCo());
    }

    [Button]
    private void FireProcess()
    {
        var objectToThrow = Instantiate(_objectToFirePrefab, _barrelPoint);
        objectToThrow.transform.DOMoveZ(_barrelPoint.transform.position.z + PlayerData.Range, _arriveTimeOfThrow);
        Destroy(objectToThrow, _destroyTimeOfObjectToFire);
    }

    private IEnumerator FireRateCo()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f / PlayerData.FireRate);
            FireProcess();
        }
    }
}
