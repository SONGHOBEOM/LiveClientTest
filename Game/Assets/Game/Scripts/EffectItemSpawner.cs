using UnityEngine;

public class EffectItemSpawner : MonoBehaviour
{
    private EffectItemSO _effectItemSo;

    private void Start()
    {
        if (GameDataManager.Instance.TryGetData<EffectItemSO>(out var effectItemSo))
            _effectItemSo = effectItemSo;

        Spawn();
    }

    public void Spawn()
    {
        var speedUpItem = Instantiate(_effectItemSo.SpeedUpEffect.prefab);
        speedUpItem.SetData(_effectItemSo.SpeedUpEffect);

        var hpUpItem = Instantiate(_effectItemSo.MaxHpUpEffect.prefab);
        hpUpItem.SetData(_effectItemSo.MaxHpUpEffect);
    }
}