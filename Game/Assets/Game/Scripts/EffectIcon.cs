using System;
using UnityEngine;
using UnityEngine.UI;

public class EffectIcon : MonoBehaviour
{
    [SerializeField] private Image effectImage;
    [SerializeField] private Text remainTimeText;

    private EffectItemSO.EffectItemData _effectItemData;
    
    public void InitIcon(EffectItemSO.EffectItemData effectItemData)
    {
        gameObject.SetActive(true);
        
        _effectItemData = effectItemData;
        effectImage.sprite = effectItemData.effectSprite;

        var effect = EffectManager.Instance.GetEffect(effectItemData);
        if (effect != null)
        {
            remainTimeText.text = effect.RemainTime.ToString("F1") + "s";
        }
    }

    private void Update()
    {
        var effect = EffectManager.Instance.GetEffect(_effectItemData);
        if (effect != null)
        {
            remainTimeText.text = effect.RemainTime > 0 ? effect.RemainTime.ToString("F1") + "s" : "";
        }
        else
        {
            remainTimeText.text = "";
        }
        
        if(string.IsNullOrEmpty(remainTimeText.text))
            gameObject.SetActive(false);
    }
}
