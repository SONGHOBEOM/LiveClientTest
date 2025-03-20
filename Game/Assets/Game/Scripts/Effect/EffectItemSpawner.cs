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

    private void Spawn()
    {
        var speedUpItem = Instantiate(_effectItemSo.SpeedUpEffect.prefab, Vector3.left, Quaternion.identity);
        speedUpItem.SetData(_effectItemSo.SpeedUpEffect);

        var hpUpItem = Instantiate(_effectItemSo.MaxHpUpEffect.prefab, Vector3.right, Quaternion.identity);
        hpUpItem.SetData(_effectItemSo.MaxHpUpEffect);
    }
}