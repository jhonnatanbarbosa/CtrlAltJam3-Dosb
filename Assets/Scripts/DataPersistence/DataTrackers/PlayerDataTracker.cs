using System.Collections;
using System.Collections.Generic;
using JUTPS;
using JUTPS.InventorySystem;
using JUTPS.ItemSystem;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDataTracker : MonoBehaviour, IDataPersistence
{
    [SerializeField] public GameObject GameObjectReference;

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
        GameObjectReference.transform.position = data.transformV;
        GameObjectReference.transform.rotation = data.quaternionV;
        GameObjectReference.GetComponent<JUHealth>().Health = data.health;
    }

    public void SaveData(ref GameData data)
    {
        Debug.Log("data trans" + data.transformV);
        Debug.Log("ref" + GameObjectReference.transform.position);
        data.transformV = GameObjectReference.transform.position;
        data.quaternionV = GameObjectReference.transform.rotation;
        data.health = GameObjectReference.GetComponent<JUHealth>().Health;
    }
}
