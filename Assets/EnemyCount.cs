using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCount : MonoBehaviour
{
	//[SerializeField]
	//JUTPS.JUCharacterController[] enemy_list;
	//public void Start()
	//{
	//	enemy_list = GetComponentsInChildren<JUTPS.JUCharacterController>();
	//	foreach (var enemy in enemy_list)
	//	{
	//		//Debug.Log(enemy.ToString());
	//		enemy.gameObject.GetComponent<JUTPS.JUHealth>();
	//		if (enemy.IsDead == true)
	//		{
	//			enemy_list.
	//		}
	//	}
	//}

	[SerializeField] List<GameObject> enemylist;
	public bool lifeCheck;
	public void Start()
	{
		LifeCheck();
		
	}

	public void LifeCheck()
	{
		enemylist = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
		foreach (var enemy in enemylist)
		{
			//Debug.Log(enemy.ToString());
			lifeCheck = enemy.gameObject.GetComponent<JUTPS.JUHealth>().IsDead;
			
		}
	}

}
