using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EffectManager : Singleton<EffectManager>
{
    private List<Effect> _effects = new();

    private void Start()
    {
        CheckEffectDuration();
    }

    public void ApplyEffect(EffectItemSO.EffectItemData effectItemData)
    {
        var effect = EffectFactory.CreateFactory(effectItemData);
        effect.ResetElapsedTime();
        
        _effects.Remove(effect);
        _effects.Add(effect);
        
        effect.ApplyEffect();
    }

    public Effect GetEffect(EffectItemSO.EffectItemData effectItemData)
    {
        foreach (var effect in _effects)
        {
            if (effect.data == effectItemData)
                return effect;
        }

        return null;
    }
    
    private async Awaitable CheckEffectDuration()
    {
        while (true)
        {
            for(var i = 0; i < _effects.Count; ++i)
            {
                var effect = _effects[i];
                
                if (effect.IsExpired)
                {
                    effect.ResetElapsedTime();
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
