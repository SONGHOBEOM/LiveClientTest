using System;
using UnityEngine;


[CreateAssetMenu(menuName = "Game/EffectItemSO", fileName = "New EffectItemSO", order = 0)]
public class EffectItemSO : ScriptableObject
{
    public enum EffectType
    {
        SpeedUp,
        MaxHpUp
    }
    
    [Serializable]
    public class EffectItemData
    {
        public EffectType effectType;
        public EffectOperator effectOperator;
        public float duration;
        public EffectItem prefab;
        public Sprite effectSprite;
    }

    [Header("Speed Up Effect")]
    [SerializeField]
    private EffectItemData speedUpData;
    public EffectItemData SpeedUpEffect=> speedUpData;

    [Header("MaxHp Up Effect")]
    [SerializeField] 
    private EffectItemData maxHpUpData;

    public EffectItemData MaxHpUpEffect => maxHpUpData;
}
