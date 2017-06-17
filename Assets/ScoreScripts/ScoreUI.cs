using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour {


    ObjectManager objectManager;
    Text text;
    

    public void setupScoreUI()
    {
        setSizeOfScoreText();
        text = GetComponent<Text>();
    }
    
	void Update () {
        text.text = "Highest Score: " + objectManager.gameScore.getHighestScore();
	}

    public void setObjectManager(ObjectManager objectManager)
    {
        this.objectManager = objectManager;
    }
    public void setSizeOfScoreText()
    {
        GetComponent<RectTransform>().sizeDelta = new Vector2(408, 54);
    }
}
