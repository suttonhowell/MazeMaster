using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoseSceneUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void returnToMenu() { 
        SceneManager.LoadScene("MainMenuScene", LoadSceneMode.Single);
    }

    public void tryAgain()
    {
        //get size of previous level and add 5 more turns
        // clear maze blueprint
        MazeBlueprint.clear();
        SceneManager.LoadScene("LevelScene", LoadSceneMode.Single);
    }

}
