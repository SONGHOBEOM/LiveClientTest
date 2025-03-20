using System;
using System.Collections.Generic;
using UnityEngine;

public partial class PlayerController : MonoBehaviour
{
    private PlayerDataSO _playerData;
    
    [Serializable]
    public struct PlayerStatValue
    {
        public float baseValue;
        public float currentValue;
        
        public void UpdateValue(float value, bool current)
        {
            if (current)
            {
                currentValue = value;
            }
            else
            {
                baseValue = value;
            }
        }
    }
    
    private Dictionary<PlayerStat, PlayerStatValue> _playerStats = new();
    private Dictionary<PlayerStat, List<EffectOperator>> _appliedBuffOperators = new();

    private void InitPlayerStats()
    {
        if (!GameDataManager.Instance.TryGetData<PlayerDataSO>(out var data))
        {
            Debug.LogError($"There is no PlayerData in GameDataRegistry!");
            return;
        }

        _playerData = data;
        
        foreach (var statValue in _playerData.PlayerStatValues)
        {
            _playerStats.Add(statValue.stat, new PlayerStatValue
            {
                baseValue = statValue.value,
                currentValue = statValue.value
            });
        }
        
        UpdateStats();
    }

    public void ApplyEffect(PlayerStat stat, EffectOperator effectOperator)
    {
        if (_appliedBuffOperators.TryGetValue(stat, out var effectOperators))
        {
            if (effectOperators.Contains(effectOperator))
                return;
            
            effectOperators.Add(effectOperator);
        }
        else
        {
            _appliedBuffOperators.Add(stat, new List<EffectOperator> {effectOperator});
        }

        UpdateStats();
    }

    public void UnApplyEffect(PlayerStat stat, EffectOperator effectOperator)
    {
        if (!_appliedBuffOperators.TryGetValue(stat, out var effectOperators))
            return;

        effectOperators.Remove(effectOperator);

        UpdateStats();
    }

    private void UpdateStats()
    {
        foreach (var keyValuePair in _appliedBuffOperators)
        {
            var sumValue = 0.0f;
            var multiplyValue = 1.0f;
            
            var stat = keyValuePair.Key;
            var buffOperators = keyValuePair.Value;

            foreach (var buffOperator in buffOperators)
            {
                sumValue += buffOperator.sumValue;
                multiplyValue *= buffOperator.multiplyValue;
            }

            var statValue = GetStat(stat, false);
            statValue += sumValue;
            statValue *= multiplyValue;
            
            SetStat(stat, statValue);
        }
    }
    
    private void SetStat(PlayerStat stat, float value, bool current = true)
    {
        if (!_playerStats.TryGetValue(stat, out var playerStat))
            return;

        playerStat.UpdateValue(value, current);

        _playerStats[stat] = playerStat;
    }

     public float GetStat(PlayerStat stat, bool current = true)
     {
         return !TryGetPlayerStatValue(stat, out var value, current) ? 0.0f : value;
     }
             
     private bool TryGetPlayerStatValue(PlayerStat stat, out float value, bool current = true)
     {
         if(!_playerStats.TryGetValue(stat, out var playerStat))
         {
             value = 0.0f;
             return false;
         }

         value = current ? playerStat.currentValue : playerStat.baseValue;
         return true;
     }
}
