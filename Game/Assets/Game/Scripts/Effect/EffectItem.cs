using UnityEngine;

public interface IPickable
{
    public void PickUp();
}

public class EffectItem : MonoBehaviour, IPickable
{
    private EffectItemSO.EffectItemData _effectItemData;

    public void SetData(EffectItemSO.EffectItemData data)
    { 
        _effectItemData = data;
    }
    
    public void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<PlayerController>();
        if (player == null)
            return;
        
        PickUp();     
    }
    
    public void PickUp()
    {
        EffectManager.Instance.ApplyEffect(_effectItemData);
        HUDController.Instance.InstantiateEffectIcon(_effectItemData);
    }
}

