using DG.Tweening;
using MangoramaStudio.Scripts.Data;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireBehaviour : MonoBehaviour
{
    [SerializeField] private Transform _barrelPoint;
    [SerializeField] private BulletBehaviour _bulletPrefab;
    [SerializeField] private float _initialBulletSpeed;

    private void Start()
    {
        StartCoroutine(FireRateCo());
    }

    [Button]
    private void FireProcess()
    {
        var bullet = Instantiate(_bulletPrefab,_barrelPoint.transform.position,_barrelPoint.transform.rotation);
        bullet.Initialize(_initialBulletSpeed);
        //objectToThrow.transform.DOMoveZ(_barrelPoint.transform.position.z + PlayerData.Range, _arriveTimeOfThrow);
        Destroy(bullet.gameObject, 1f);
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
