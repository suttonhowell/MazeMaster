using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinSceneUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Debug.Log("WINSCENEUI");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void returnToMenu()
    {
        //wipe all parameters in maze blueprint
        //reset other parameters
        MazeBlueprint.clear();
        SceneManager.LoadScene("MainMenuScene", LoadSceneMode.Single);
    }

    public void nextLevel()
    {
        //get size of previous level and add 5 more turns
        int turnCount = MazeBlueprint.path.Count;
        //inc to next level
        MazeBlueprint.level++;
        //reset other parameters
        MazeBlueprint.round = 1;
        MazeBlueprint.turn = 1;
        //generate new path
        MazeBlueprint.createPath(turnCount + 5);
        SceneManager.LoadScene("LevelScene", LoadSceneMode.Single);
    }
}
