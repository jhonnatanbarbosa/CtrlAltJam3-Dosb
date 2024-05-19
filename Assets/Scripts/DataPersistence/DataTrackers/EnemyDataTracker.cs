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
    public string id;
    public float healthTemp;
    public Vector3 transformTemp;
    public Quaternion rotationTemp;

    [ContextMenu("Generate UID")]
    private void generateUID()
    {
        id = System.Guid.NewGuid().ToString();
    }

    public void Awake()
    {
        if (GameObjectReference == null)
        {
            GameObjectReference = gameObject;
        }

        if (id == null)
        {
            generateUID();
        }
    }

    public void LoadData(GameData data)
    {
        data.EnemyHealthDic.TryGetValue(id, out healthTemp);
        if (healthTemp <= 0)
        {
            GameObjectReference.GetComponent<JUHealth>().IsDead = true;
        }
        data.EnemyTransformDic.TryGetValue(id, out transformTemp);
        data.EnemyRotationDic.TryGetValue(id, out rotationTemp);
        if (transformTemp != null)
        {
            GameObjectReference.transform.position = transformTemp;
        }
        if (rotationTemp != null)
        {
            GameObjectReference.transform.rotation = rotationTemp;
        }
    }

    public void SaveData(ref GameData data)
    {
        if (data.EnemyHealthDic.ContainsKey(id))
        {
            data.EnemyHealthDic.Remove(id);
        }
        data.EnemyHealthDic.Add(id, GameObjectReference.GetComponent<JUHealth>().Health);
        if (data.EnemyTransformDic.ContainsKey(id))
        {
            data.EnemyTransformDic.Remove(id);
        }
        data.EnemyTransformDic.Add(id, GameObjectReference.transform.position);
        if (data.EnemyRotationDic.ContainsKey(id))
        {
            data.EnemyRotationDic.Remove(id);
        }
        data.EnemyRotationDic.Add(id, GameObjectReference.transform.rotation);
    }
}
