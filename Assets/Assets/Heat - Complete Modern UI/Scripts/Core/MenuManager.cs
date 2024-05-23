using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Michsky.UI.Heat
{
    [DisallowMultipleComponent]
    public class MenuManager : MonoBehaviour
    {
        // Resources
        public UIManager UIManagerAsset;
        public Animator splashScreen;
        [SerializeField] private GameObject mainContent;
        [SerializeField] private ImageFading initPanel;

        [SerializeField] private AudioClip part1;
        [SerializeField] private AudioClip part2;
        [SerializeField] private AudioSource audioSource;

        // Helpers
        float splashInTime;
        float splashOutTime;

        

        void Awake()
        {
            Time.timeScale = 1;

            if (initPanel != null) { initPanel.gameObject.SetActive(true); }
            if (splashScreen != null) { splashScreen.gameObject.SetActive(false); }
        }

        void Start()
        {
            audioSource = GetComponent<AudioSource>();

            if (audioSource == null)
            {
            // If there is no AudioSource component, add one
            audioSource = gameObject.AddComponent<AudioSource>();
            }

             PlayFirstClip();   

            StartCoroutine("StartInitialize");
        }

        void PlayFirstClip()
    {
        if (part1 != null)
        {
            audioSource.clip = part1;
            audioSource.loop = false; // Ensure the first clip does not loop
            audioSource.Play();
            Invoke("PlaySecondClip", part1.length); // Schedule the second clip to play after the first one ends
        }
    }

    void PlaySecondClip()
    {
        if (part2 != null)
        {
            audioSource.clip = part2;
            audioSource.loop = true; // Ensure the second clip loops
            audioSource.Play();
        }
    }


        public void DisableSplashScreen() 
        {
            StopCoroutine("DisableSplashScreenAnimator");
            StartCoroutine("FinalizeSplashScreen");

            splashScreen.enabled = true;
            splashScreen.Play("Out");
            
        }

        void Initialize()
        {
            if (UIManagerAsset == null || mainContent == null)
            {
                Debug.LogError("<b>[Heat UI]</b> Cannot initialize the resources due to missing resources.", this);
                return;
            }

            mainContent.gameObject.SetActive(false);
            bool enableSplashAfter = false;

            if (UIManagerAsset.enableSplashScreen && UIManagerAsset.showSplashScreenOnce && GameObject.Find("[Heat UI - Splash Screen Helper]") != null)
            {
                UIManagerAsset.enableSplashScreen = false;
                enableSplashAfter = true;
            }

            if (UIManagerAsset.enableSplashScreen)
            {
                if (splashScreen == null)
                {
                    Debug.LogError("<b>[Heat UI]</b> Splash Screen is enabled but its resource is missing. Please assign the correct variable for 'Splash Screen'.", this);
                    return;
                }

                // Getting in and out animation length
                AnimationClip[] clips = splashScreen.runtimeAnimatorController.animationClips;
                splashInTime = clips[0].length;
                splashOutTime = clips[1].length;

                splashScreen.enabled = true;
                splashScreen.gameObject.SetActive(true);
                StartCoroutine("DisableSplashScreenAnimator");

                if (UIManagerAsset.showSplashScreenOnce)
                {
                    GameObject tempHelper = new GameObject();
                    tempHelper.name = "[Heat UI - Splash Screen Helper]";
                    DontDestroyOnLoad(tempHelper);
                }
            }

            else
            {
                if (mainContent == null)
                {
                    Debug.LogError("<b>[Heat UI]</b> 'Main Panels' is missing. Please assign the correct variable for 'Main Panels'.", this);
                    return;
                }

                if (splashScreen != null) { splashScreen.gameObject.SetActive(false); }
                mainContent.gameObject.SetActive(false);
                StartCoroutine("FinalizeSplashScreen");
            }

            if (enableSplashAfter && UIManagerAsset.showSplashScreenOnce)
            {
                UIManagerAsset.enableSplashScreen = true;
            }
        }

        IEnumerator StartInitialize()
        {
            yield return new WaitForSeconds(0.5f);
            if (initPanel != null) { initPanel.FadeOut(); }
            Initialize();
        }

        IEnumerator DisableSplashScreenAnimator()
        {
            yield return new WaitForSeconds(splashInTime + 0.1f);
            splashScreen.enabled = false;
        }

        IEnumerator FinalizeSplashScreen()
        {
            yield return new WaitForSeconds(splashOutTime + 0.1f);
           
            if (UIManagerAsset != null && UIManagerAsset.enableSplashScreen) 
            {
                splashScreen.gameObject.SetActive(false); 
            }

            mainContent.gameObject.SetActive(true);

            if (ControllerManager.instance != null
                && ControllerManager.instance.gamepadEnabled
                && ControllerManager.instance.firstSelected != null
                && ControllerManager.instance.firstSelected.activeInHierarchy)
            {
                EventSystem.current.SetSelectedGameObject(ControllerManager.instance.firstSelected);
            }
        }
    }
}