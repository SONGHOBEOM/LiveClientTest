using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/PlayerDataSO", fileName = "New PlayerDataSO", order = 1)]
public class PlayerDataSO : ScriptableObject
{
    [Serializable]
    public struct PlayerStatValue
    {
        public PlayerStat stat;
        public float value;
    }

    [SerializeField] 
    private List<PlayerStatValue> playerStatValues = new();
    public List<PlayerStatValue> PlayerStatValues => playerStatValues;
}
