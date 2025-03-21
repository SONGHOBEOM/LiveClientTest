using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class EffectFactory
{
    private static readonly List<Effect> EffectCaches = new();
    public static Effect CreateFactory(EffectItemSO.EffectItemData data)
    {
        if (EffectCaches.Any(x => x.effectType == data.effectType))
            return EffectCaches.FirstOrDefault(x => x.effectType == data.effectType);
        
        switch (data.effectType)
        {
            case EffectItemSO.EffectType.SpeedUp:
                var speedUpEffect = new SpeedUpEffect(data);
                EffectCaches.Add(speedUpEffect);
                return speedUpEffect;
            
            case EffectItemSO.EffectType.MaxHpUp:
                var maxHpUpEffect = new MaxHpUpEffect(data);
                EffectCaches.Add(maxHpUpEffect);
                return maxHpUpEffect;
        }

        return default;
    }
}

public abstract class Effect
{
    public EffectItemSO.EffectType effectType;
    public EffectItemSO.EffectItemData data;

    public float Duration { get; protected set; }
    public float ElapsedTime { get; protected set; }

    public float RemainTime => Duration - ElapsedTime;

    public bool IsExpired => ElapsedTime >= Duration;
    protected PlayerController PlayerController => EntityManager.Instance.PlayerController;
    
    public Effect(EffectItemSO.EffectItemData data)
    {
        this.data = data;
        effectType = data.effectType;
        Duration = data.duration;
        ElapsedTime = 0;
    }
    
    public abstract void ApplyEffect();
    public abstract void UnApplyEffect();

    public void Update(float deltaTime)
    {
        ElapsedTime += deltaTime;
    }

    public void ResetElapsedTime() => ElapsedTime = 0;
}

public class SpeedUpEffect : Effect
{
    public SpeedUpEffect(EffectItemSO.EffectItemData data) : base(data)
    {
    }
    public override void ApplyEffect()
    {
        PlayerController.ApplyEffect(PlayerStat.MoveSpeed, data.effectOperator);
    }

    public override void UnApplyEffect()
    {
        PlayerController.UnApplyEffect(PlayerStat.MoveSpeed, data.effectOperator);
    }
}

public class MaxHpUpEffect : Effect
{
    public MaxHpUpEffect(EffectItemSO.EffectItemData data) : base(data)
    {
    }
    public override void ApplyEffect()
    {
        PlayerController.ApplyEffect(PlayerStat.MaxHealth, data.effectOperator);
    }

    public override void UnApplyEffect()
    {
        PlayerController.UnApplyEffect(PlayerStat.MaxHealth, data.effectOperator);
    }
}

[Serializable]
public struct EffectOperator : IEquatable<EffectOperator>
{
    public float sumValue;
    public float multiplyValue;

    public EffectOperator(float sumValue, float multiplyValue)
    {
        this.sumValue = sumValue;
        this.multiplyValue = multiplyValue;
    }

    public void SetDefault()
    {
        sumValue = 0;
        multiplyValue = 1;
    }

    public bool Equals(EffectOperator other)
    {
        return Mathf.Approximately(sumValue, other.sumValue) &&
               Mathf.Approximately(multiplyValue, other.multiplyValue);
    }
}