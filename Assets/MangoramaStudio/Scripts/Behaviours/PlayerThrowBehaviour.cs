using DG.Tweening;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrowBehaviour : MonoBehaviour
{
    [SerializeField] private Transform _barrelPoint;
    [SerializeField] private GameObject _objectToThrow;
    [SerializeField] private float _destroyTimeOfObjectToThrow; //objenin katettiði mesafe buradan manipüle edilecek
    [SerializeField] private float _rangeOfThrowingOnZAxis; //objenin ne kadar uzaða fýrlatýldýðý buradan manipüle edilecek
    [SerializeField] private float _arriveTimeOfThrow;  //objenin fýrlatýlma hýzý buradan manipüle edilecek(ters mantýk)

    [Button]
    private void ObjectThrowProcess()
    {
        var objectToThrow = Instantiate(_objectToThrow, _barrelPoint);
        objectToThrow.transform.DOMoveZ(_rangeOfThrowingOnZAxis, _arriveTimeOfThrow);
        Destroy(objectToThrow, _destroyTimeOfObjectToThrow);
    }
}
