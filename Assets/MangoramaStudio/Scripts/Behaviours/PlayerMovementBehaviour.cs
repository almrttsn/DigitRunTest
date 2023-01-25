using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBehaviour : MonoBehaviour
{
    public bool PlayerMovementRestricted { get; set; }

    public float PlayerSpeed { get; set; }

    private PlayerController _playerController;

    public void Initialize(PlayerController playerController)
    {
        _playerController = playerController;
        PlayerSpeed = 7.5f;
        InputController.OnDrag += Dragged;
    }

    private void Update()
    {
        if (PlayerMovementRestricted == false)
        {
            transform.position += new Vector3(0, 0, PlayerSpeed) * Time.deltaTime;
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.5f, 2.5f), transform.position.y, transform.position.z);
        }
    }

    private void Dragged(Vector2 dragVector)
    {
        transform.position += new Vector3(dragVector.x * 100f, 0, 0) * Time.deltaTime;
    }

    private void OnDestroy()
    {
        InputController.OnDrag -= Dragged;
    }
}
