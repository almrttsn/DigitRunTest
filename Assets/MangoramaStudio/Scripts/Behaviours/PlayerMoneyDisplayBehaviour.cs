using MangoramaStudio.Scripts.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoneyDisplayBehaviour : MonoBehaviour
{
    [SerializeField] private TextMesh _playerMoneyDisplayText;

    private void Update()
    {
        _playerMoneyDisplayText.text = PlayerData.Money.ToString();
    }
}
