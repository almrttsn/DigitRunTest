using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerDetectorBehaviour PlayerDetectorBehaviour => _playerDetectorBehaviour;
    public PlayerFireBehaviour PlayerFireBehaviour => _playerFireBehaviour;
    public PlayerMoneyDisplayBehaviour PlayerMoneyDisplayBehaviour => _playerMoneyDisplayBehaviour;
    public PlayerMovementBehaviour PlayerMovementBehaviour => _playerMovementBehaviour;

    [SerializeField] private PlayerDetectorBehaviour _playerDetectorBehaviour;
    [SerializeField] private PlayerFireBehaviour _playerFireBehaviour;
    [SerializeField] private PlayerMoneyDisplayBehaviour _playerMoneyDisplayBehaviour;
    [SerializeField] private PlayerMovementBehaviour _playerMovementBehaviour;

    private void Start()
    {
        PlayerDetectorBehaviour.Initialize(this);
        PlayerFireBehaviour.Initialize(this);
        PlayerMoneyDisplayBehaviour.Initialize(this);
        PlayerMovementBehaviour.Initialize(this);        
    }
}
