using MangoramaStudio.Scripts.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoneyDisplayBehaviour : MonoBehaviour
{
    [SerializeField] private TextMesh _playerMoneyDisplayText;
    private PlayerController _playerController;


    public void Initialize(PlayerController playerController)
    {
        _playerController = playerController;
    }

    private void Update()
    {
        _playerMoneyDisplayText.text = PlayerData.Money.ToString();
    }

}
