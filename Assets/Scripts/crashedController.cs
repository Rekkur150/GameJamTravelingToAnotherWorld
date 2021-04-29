using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;

public class crashedController : MonoBehaviour
{

    public Button tryAgain;
    public Button menuButton;
    public GameObject menuPanel;
    public GameObject scoreOnTop;
    public Text finalScoreText;


    // Start is called before the first frame update
    void Start()
    {

    }

    public void crashed(ulong finalScore) {
        scoreOnTop.SetActive(false);
        menuPanel.SetActive(true);

        finalScoreText.text = "" + finalScore;

    }
}
