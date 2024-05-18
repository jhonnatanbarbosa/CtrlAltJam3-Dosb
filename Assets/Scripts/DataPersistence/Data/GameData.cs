using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public long LastUpdated;
    public int DeathCount;
    public int DetectionCount;
    public int CurrentScene;

    public Vector3 transformV;
    public Quaternion quaternionV;
    public float health;
    public SerializableDictionary<string, float> EnemyHealthDic;
    public SerializableDictionary<string, Vector3> EnemyTransformDic;
    public SerializableDictionary<string, Quaternion> EnemyRotationDic;

    public GameData() {
        this.DeathCount = 0;
        this.DetectionCount = 0;
        this.CurrentScene = 0;
        this.health = 400;
        this.transformV = new Vector3();
        this.quaternionV = new Quaternion();
        this.EnemyHealthDic = new SerializableDictionary<string, float>();
        this.EnemyTransformDic = new SerializableDictionary<string, Vector3>();
        this.EnemyRotationDic = new SerializableDictionary<string, Quaternion>();
    }
}
