using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;


public class UIController : MonoBehaviour
{
    [SerializeField] Text levelLabel;
    [SerializeField] Text roundLabel;
    [SerializeField] Text instructions;
    private string format = "D1"; 

    void Start()
    {
        updateUI();
        //only show instructions on first round of each level
        if (MazeBlueprint.round > 1)
        {
            instructions.text = "";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void updateUI()
    {
        levelLabel.text = "Level " + MazeBlueprint.level.ToString(format);
        roundLabel.text = "Round " + MazeBlueprint.round.ToString(format) + "/" + MazeBlueprint.path.Count.ToString(format);
    }
}
