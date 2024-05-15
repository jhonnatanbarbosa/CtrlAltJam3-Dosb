using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    static public Main Instance;

    public int switchCount;
    //public GameObject winText;
    private int onCount = 0;

    [SerializeField] JUTPS.Utilities.SimpleLevelTransition levelScript;

    private void Awake()
    {
        Instance = this;
        Cursor.lockState = CursorLockMode.None;
    }
    public void SwitchChange(int points) {
        onCount = onCount + points;
        if (onCount == switchCount)
        {
            //winText.SetActive(true);
            levelScript.LoadGame();
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
