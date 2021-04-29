using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine;

public class SceneMan : MonoBehaviour
{
    public GameObject FadingPanel;
    
    private string NextScene;
    private AnimationController FadingAnimationController;

    // Start is called before the first frame update
    void Start()
    {

        FadingAnimationController = FadingPanel.GetComponent<AnimationController>();
        FadingAnimationController.animationEvent.AddListener(loadScene);
    }

    public void restartScene() {
        NextScene = "TravelingScene";
        FadingAnimationController.fade();
    }

    public void menuScene() {
        NextScene = "TitleScreen";
        FadingAnimationController.fade();
    }

    public void loadScene() {
        SceneManager.LoadScene(NextScene, LoadSceneMode.Single);
    }
}
