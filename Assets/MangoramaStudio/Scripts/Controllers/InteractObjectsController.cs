using MangoramaStudio.Scripts.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractObjectsController : MonoBehaviour
{
    public event Action<int> AllDoorsOpened;

    public EndTriggerBehaviour EndTriggerBehaviour => _endTriggerBehaviour;
    public List<DoorBehaviour> DoorBehaviourList => _doorBehaviourList;
    public List<FireRateGateScoreBehaviour> FireRateGateScoreBehaviourList => _fireRateGateScoreBehaviourList;
    public List<MoneyBehaviour> MoneyBehaviourList => _moneyBehaviourList;
    public List<RangeGateScoreBehaviour> RangeGateScoreBehaviourList => _rangeGateScoreBehaviourList;

    [SerializeField] private EndTriggerBehaviour _endTriggerBehaviour;
    [SerializeField] private List<DoorBehaviour> _doorBehaviourList;
    [SerializeField] private List<FireRateGateScoreBehaviour> _fireRateGateScoreBehaviourList;
    [SerializeField] private List<MoneyBehaviour> _moneyBehaviourList;
    [SerializeField] private List<RangeGateScoreBehaviour> _rangeGateScoreBehaviourList;

    private GameManager _gameManager;

    public void Initialize(GameManager gameManager)
    {
        _gameManager = gameManager;
        for (int i = 0; i < DoorBehaviourList.Count; i++)
        {
            _doorBehaviourList[i].Initialize(this);
        }
        for (int i = 0; i < FireRateGateScoreBehaviourList.Count; i++)
        {
            _fireRateGateScoreBehaviourList[i].Initialize(this);
        }
        for (int i = 0; i < MoneyBehaviourList.Count; i++)
        {
            _moneyBehaviourList[i].Initialize(this);
        }
        for (int i = 0; i < RangeGateScoreBehaviourList.Count; i++)
        {
            _rangeGateScoreBehaviourList[i].Initialize(this);
        }
    }
}
