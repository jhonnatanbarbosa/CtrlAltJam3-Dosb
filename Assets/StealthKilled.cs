using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealthKilled : MonoBehaviour
{
    public BoxCollider triggerArea;
    [SerializeField] StabbingBHVR stabbingBHVR;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        stabbingBHVR = player.GetComponent<StabbingBHVR>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void OnTriggerStay(Collider other)
	{
        if (other.gameObject.tag == "Player")
        {
            stabbingBHVR.canStab = true;
        }
        
	}

	public void OnTriggerExit(Collider other)
	{
        if (other.gameObject.tag == "Player")
        {
            stabbingBHVR.canStab = false;
        }
    }
}
