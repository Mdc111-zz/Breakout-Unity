using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameScore
{
    private int currentGameScore;
    private int highestScore;
    ObjectManager objectManager;

    public GameScore(ObjectManager instance)
    {
        objectManager = instance;
        currentGameScore = 0;
        highestScore = getHighScoreFromFile();
    }

    public int getHighScoreFromFile()
    {
        return int.Parse(objectManager.scoreFile.ReadFromFile());
    }

    public int getCurrentGameScore()
    {
        return currentGameScore;
    }

    public void setCurrentGameScore(int currentGameScore)
    {
        this.currentGameScore = currentGameScore;
    }

    public int getHighestScore()
    {
        if (currentGameScore >= highestScore)
        {
            highestScore = currentGameScore;
            return currentGameScore;
        }

        return highestScore;
    }

    public void setHighestScore(int highestScore)
    {
        this.highestScore = highestScore;
    }

    public void addToScore(int n) { currentGameScore += n; }


}
