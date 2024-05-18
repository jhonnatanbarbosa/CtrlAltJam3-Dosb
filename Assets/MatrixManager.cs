using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixManager : MonoBehaviour
{
    [SerializeField] Main _miniScript;
    // Start is called before the first frame update
    void Start()
    {
        _miniScript.EndMinigame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void OnTriggerStay(Collider other)
	{
        if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.F))
        {
            _miniScript.StartMinigame();
        }
	}
}
