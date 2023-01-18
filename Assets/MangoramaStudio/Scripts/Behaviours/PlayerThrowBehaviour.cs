using DG.Tweening;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrowBehaviour : MonoBehaviour
{
    [SerializeField] private Transform _barrelPoint;
    [SerializeField] private GameObject _objectToThrow;
    [SerializeField] private float _destroyTimeOfObjectToThrow; //objenin katetti�i mesafe buradan manip�le edilecek
    [SerializeField] private float _rangeOfThrowingOnZAxis; //objenin ne kadar uza�a f�rlat�ld��� buradan manip�le edilecek
    [SerializeField] private float _arriveTimeOfThrow;  //objenin f�rlat�lma h�z� buradan manip�le edilecek(ters mant�k)

    [Button]
    private void ObjectThrowProcess()
    {
        var objectToThrow = Instantiate(_objectToThrow, _barrelPoint);
        objectToThrow.transform.DOMoveZ(_rangeOfThrowingOnZAxis, _arriveTimeOfThrow);
        Destroy(objectToThrow, _destroyTimeOfObjectToThrow);
    }
}
