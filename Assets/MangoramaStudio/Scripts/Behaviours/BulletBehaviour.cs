using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private float _bulletSpeed;

    public void Initialize(float bulletSpeed)
    {
        _bulletSpeed = bulletSpeed;
    }

    private void Update()
    {
        transform.position += new Vector3(0, 0, _bulletSpeed) * Time.deltaTime;
    }
}
