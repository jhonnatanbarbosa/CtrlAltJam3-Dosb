using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carregarLevel : MonoBehaviour
{
    //load scene
    public void LoadScene(string sceneName)
    {
        Application.LoadLevel(sceneName);
    }

    

}
