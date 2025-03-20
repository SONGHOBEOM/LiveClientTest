using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EffectManager : Singleton<EffectManager>
{
    private List<Effect> _effects = new();
    
    private Awaitable _checkEffectDurationAwaitable;

    private void Start()
    {
        _checkEffectDurationAwaitable = CheckEffectDuration();
    }

    public void ApplyEffect(EffectItemSO.EffectItemData effectItemData)
    {
        var buff = EffectFactory.CreateFactory(effectItemData);
        _effects.Add(buff);
        buff.ApplyEffect();

        if (_checkEffectDurationAwaitable == null || _checkEffectDurationAwaitable.IsCompleted)
            _checkEffectDurationAwaitable = CheckEffectDuration();
    }
    
    private async Awaitable CheckEffectDuration()
    {
        while (_effects.Count > 0)
        {
            for(var i = 0; i < _effects.Count; ++i)
            {
                var effect = _effects[i];
                
                if (effect.IsExpired)
                {
                    effect.UnApplyEffect();
                    _effects.Remove(effect);
                    continue;
                }

                effect.Update(Time.deltaTime);
            }

            await Awaitable.NextFrameAsync();
        }
    }
}
