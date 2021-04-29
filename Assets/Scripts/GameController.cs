using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public ObstacleController obstacleController;
    public crashedController crashedController;
    public PlayerController PlayerController;
    public Text score;

    private ulong startingTime = 3600;
    private ulong time;
    private float timeBuffer = 0f;
    private float secondsToMinutes = 0.0002777f;
    private string scoreText = "SCORE:";
    private bool crashed = false;
    private int gameType = 0;


    // Start is called before the first frame update
    void Start()
    {


        Settings[] tempSettings = FindObjectsOfType<Settings>();
        if (tempSettings.Length > 0) {
            Debug.Log("No settings D=");
            gameType = tempSettings[0].gameType;
        }

        time = startingTime;
        setObstacleDifficulty();



    }

    // Update is called once per frame
    void Update()
    {
        if (!crashed) {
            timeBuffer += Time.deltaTime;

            if (timeBuffer > 1) {
                time++;
            }

            setObstacleDifficulty();

            score.text = scoreText + " " + (time-startingTime);
        }
    }

    void setObstacleDifficulty() {

        switch (gameType) {
            case 0:
                obstacleController.ObstacleSpeed = (7*Mathf.Log(time*(1f/700f)*secondsToMinutes))+80;
                obstacleController.ObstacleSpawnerRate = (-5.5f*Mathf.Log(time*(1f/450f)*secondsToMinutes)-5)/(obstacleController.ObstacleSpeed);
                break;
            case 1:
                obstacleController.ObstacleSpeed = (10*Mathf.Log(time*secondsToMinutes*secondsToMinutes))+100;
                obstacleController.ObstacleSpawnerRate = (-5.5f*Mathf.Log(time*secondsToMinutes*secondsToMinutes)-5)/(obstacleController.ObstacleSpeed);
                break;
        }


    }

    public void onCrashed() {
        Cursor.lockState = CursorLockMode.None;
        crashed = true;
        crashedController.crashed(time-startingTime);
        PlayerController.enabled = false;
        obstacleController.generating = false;
    }

    public void quit() {
        Application.Quit();
    }
}
