using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveMinigame : MonoBehaviour
{
    //public GameObject minigame;
    public GameObject mainCam;
    // Start is called before the first frame update
    void Start()
    {
        //minigame.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void OnTriggerStay(Collider other)
	{
        if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.F))
        {
            //minigame.SetActive(true);
            mainCam.GetComponent<JUTPS.CameraSystems.TPSCameraController>().enabled = false;
        }
	}

	public void OnTriggerExit(Collider other)
	{
        if (other.gameObject.tag == "Player")
        {
            //minigame.SetActive(false);
            mainCam.GetComponent<JUTPS.CameraSystems.TPSCameraController>().enabled = true;
        }
    }
}
