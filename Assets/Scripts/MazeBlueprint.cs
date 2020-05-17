using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public static class MazeBlueprint{
    public static ArrayList path = new ArrayList();
    //level of the game the player is on
    public static int level = 1;
    //the turn at which the next sign will appear
    public static int round = 1;
    //the turn that the player is currently at
    public static int turn = 1;

    public static void createPath(int length) {
        clear();
        //clear old path
        path.Clear();
        //populate maze path with random left and right turns
        System.Random rand = new System.Random();

        //generate random left or right turns to create maze path
        for (int i = 0; i < length; i++)
        {
            //add left turn randomly
            if (rand.NextDouble() < 0.5) {
                path.Add(0);
                UnityEngine.Debug.Log("left");
            }
            //add right turn randomly
            else
            {
                path.Add(1);
                UnityEngine.Debug.Log("right");
            }
        }

        
    }

    public static bool wrongTurn(int direction)
    {
        if ((int)path[turn - 1] != direction) return true;
        return false;
    }

    public static void clear()
    {
        path = new ArrayList();
        turn = 1;
        round = 1;
        level = 1;

    }
}


