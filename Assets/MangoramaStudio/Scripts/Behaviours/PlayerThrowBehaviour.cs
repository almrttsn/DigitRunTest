using DG.Tweening;
using MangoramaStudio.Scripts.Data;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrowBehaviour : MonoBehaviour
{
    [SerializeField] private Transform _barrelPoint;
    [SerializeField] private GameObject _objectToThrowPrefab;
    [SerializeField] private float _speedFactor;
    [SerializeField] private float _rangeOfThrowingOnZAxis;
    [SerializeField] private float _arriveTimeOfThrow;
    [SerializeField] private float _destroyTimeOfObjectToThrow;

    private void Start()
    {
        StartCoroutine(FireRateCo());
    }

    [Button]
    private void ObjectThrowProcess()
    {
        var objectToThrow = Instantiate(_objectToThrowPrefab, _barrelPoint);
        objectToThrow.transform.DOMoveZ(_barrelPoint.transform.position.z + _rangeOfThrowingOnZAxis, _arriveTimeOfThrow);
        Destroy(objectToThrow, _destroyTimeOfObjectToThrow);
    }

    private IEnumerator FireRateCo()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f / PlayerData.FireRate);
            ObjectThrowProcess();
        }
    }
}
