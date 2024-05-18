using UnityEngine;
using UnityEngine.SceneManagement;
namespace JUTPS.Utilities
{
    [AddComponentMenu("JU TPS/Scene Management/Trigger Load Level")]
    public class SimpleLevelTransition : MonoBehaviour
    {
        [SerializeField] string DesiredLevelName = "Hub";
        private void OnTriggerEnter(Collider col)
        {
            if (col.tag == "Player")
            {
                SaveGame();
                SceneManager.LoadScene(DesiredLevelName, LoadSceneMode.Additive);
            }
        }
        public void SaveGame()
        {
            PlayerPrefs.SetString("Level", SceneManager.GetActiveScene().name);
            PlayerPrefs.Save();
            print("Game saved!");
        }

        public void LoadGame()
        {
            SceneManager.LoadScene(PlayerPrefs.GetString("Level"));
            print("Game loaded!");
        }
    }
}
