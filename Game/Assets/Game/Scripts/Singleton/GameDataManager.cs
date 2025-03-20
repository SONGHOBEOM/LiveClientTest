using System;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : Singleton<GameDataManager>
{
    [SerializeField] private List<ScriptableObject> gameDatas;
    
    public bool TryGetData<T>(out T data) where T : ScriptableObject
    {
        foreach (var gameData in gameDatas)
        {
            if(gameData is not T scriptableObject)
                continue;

            data = scriptableObject;
            return true;
        }

        Debug.LogError($"GameDataManager Has not Data Type {typeof(T)}");
        
        data = null;
        return false;
    }
}
