using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScoreFile {
    
    ObjectManager objectManager;

    public ScoreFile(ObjectManager objectManager)
    {
        this.objectManager = objectManager;
    }

    private bool checkFileExists()
    {
        string fileCheck = @"D:\Programming\Programming Projects\Breakout Game\Breakout Game\Score.txt";
        if (File.Exists(fileCheck))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void createFile()
    {
        File.Create(@"D:\Programming\Programming Projects\Breakout Game\Breakout Game\Score.txt");
    }

    public void WriteToFile()
    {
        if (checkFileExists())
            File.WriteAllText(@"D:\Programming\Programming Projects\Breakout Game\Breakout Game\Score.txt", objectManager.gameScore.getHighestScore() + "");
        else { 
            createFile();
            File.WriteAllText(@"D:\Programming\Programming Projects\Breakout Game\Breakout Game\Score.txt", "0");
        }   
    }

    public string ReadFromFile() {
        if (checkFileExists())
            return File.ReadAllText(@"D:\Programming\Programming Projects\Breakout Game\Breakout Game\Score.txt");
        else{
            createFile();
            return File.ReadAllText(@"D:\Programming\Programming Projects\Breakout Game\Breakout Game\Score.txt");
        }
    }

}

