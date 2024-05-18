using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using JUTPS;
using JUTPS.InventorySystem;
using TMPro;
using UnityEngine;

public class EnemyDataTracker : MonoBehaviour, IDataPersistence
{

    public GameObject GameObjectReference;
    // private EnemyAttributes EnemyDataSO;
    public string id;

    [ContextMenu("Generate UID")]
    private void generateUID()
    {
        id = System.Guid.NewGuid().ToString();
    }

    public void Awake()
    {
        if(GameObjectReference == null) {
            GameObjectReference = gameObject;
        }

        if (id == null)
        {
            generateUID();
        }
    }

    public void LoadData(GameData data)
    {
        // data.EnemyData.TryGetValue(id, out EnemyDataSO);
        // if (EnemyDataSO != null)
        // {
        //     GameObjectReference.GetComponent<JUHealth>().Health = EnemyDataSO.healthF;
        //     GameObjectReference.transform.position = EnemyDataSO.transformV;
        //     GameObjectReference.transform.rotation = EnemyDataSO.rotationV;
        //     GameObjectReference.GetComponent<JUInventory>().AllItems = EnemyDataSO.itemsArray;
        // }
    }

    public void SaveData(ref GameData data)
    {
        // if (data.EnemyData.ContainsKey(id))
        // {
        //     data.EnemyData.Remove(id);
        // }
        // EnemyDataSO.healthF = GameObjectReference.GetComponent<JUHealth>().Health;
        // EnemyDataSO.transformV = GameObjectReference.transform.position;
        // EnemyDataSO.rotationV = GameObjectReference.transform.rotation;
        // // EnemyDataSO.itemsArray = GameObjectReference.GetComponent<JUInventory>().AllItems;
        // data.EnemyData.Add(id, EnemyDataSO);
    }
}
