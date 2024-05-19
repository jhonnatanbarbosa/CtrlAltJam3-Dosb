using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    static public Main Instance;

    public int switchCount;
    public GameObject winText;
    private int onCount = 0;
    public GameObject _tudo;
    public GameObject _mG;

    private void Awake()
    {
        Instance = this;
        
    }
    public void SwitchChange(int points) {
        onCount = onCount + points;
        if (onCount == switchCount)
		{
			//winText.SetActive(true);
			EndMinigame();
		}
	}

	public void EndMinigame()
	{
		_tudo.SetActive(true);
		_mG.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void StartMinigame()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        _tudo.SetActive(false);
        _mG.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
