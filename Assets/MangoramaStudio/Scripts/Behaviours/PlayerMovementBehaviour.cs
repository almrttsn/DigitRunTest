using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBehaviour : MonoBehaviour
{
    [SerializeField] private float _playerSpeed;
    private PlayerController _playerController;

    public void Initialize(PlayerController playerController)
    {
        _playerController = playerController;
        InputController.OnDrag += Dragged;
    }

    private void Update()
    {
        transform.position += new Vector3(0, 0, _playerSpeed) * Time.deltaTime;
    }

    private void Dragged(Vector2 dragVector)
    {
        transform.position += new Vector3(dragVector.x * 100f, 0, 0) * Time.deltaTime;
    }
}
