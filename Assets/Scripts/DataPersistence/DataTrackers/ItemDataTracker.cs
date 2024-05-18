using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDataTracker : MonoBehaviour, IDataPersistence
{
    // private string DataTag = "ItemData";

    [SerializeField] private string id;

    [ContextMenu("Generate UID")]
    private void generateUID() {
        id = System.Guid.NewGuid().ToString();
    }
    
    public void LoadData(GameData data)
    {
        throw new System.NotImplementedException();
    }

    public void SaveData(ref GameData data)
    {
        throw new System.NotImplementedException();
    }
}
