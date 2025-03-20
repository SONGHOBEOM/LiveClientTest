using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : Singleton<HUDController>
{
    [SerializeField] private Slider slider;
    [SerializeField] private Text hpText;
    [SerializeField] private Transform effectIconTransform;
    [SerializeField] private EffectIcon effectIconPrefab;

    private Dictionary<EffectItemSO.EffectItemData, EffectIcon> _effectIcons = new();

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void Update()
    {
        slider.maxValue = EntityManager.Instance.PlayerController.GetStat(PlayerStat.MaxHealth);
        slider.value = EntityManager.Instance.PlayerController.GetStat(PlayerStat.Health);

        hpText.text = $"{slider.value} / {slider.maxValue}";
    }

    public void InstantiateEffectIcon(EffectItemSO.EffectItemData effectItemData)
    {
        if (_effectIcons.TryGetValue(effectItemData, out var icon))
        {
            icon.InitIcon(effectItemData);
            return;
        }

        var effectIcon = Instantiate(effectIconPrefab, effectIconTransform);
        effectIcon.InitIcon(effectItemData);

        _effectIcons.Add(effectItemData, effectIcon);
    }
}
