using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSize {

    ObjectManager objectManager;

    public BackgroundSize(ObjectManager instance)
    {
        objectManager = instance;
        SetSizeOfBackground();
        SetPositionOfBackground();
    }
    public void SetSizeOfBackground()
    {
        float differenceInX = 1 / GameObject.FindGameObjectWithTag("Background").GetComponent<SpriteRenderer>().bounds.size.x;
        float differenceInY = 1 / GameObject.FindGameObjectWithTag("Background").GetComponent<SpriteRenderer>().bounds.size.y;
        GameObject.FindGameObjectWithTag("Background").transform.localScale = new Vector3(objectManager.screenModel.ScreenWidth * differenceInX, objectManager.screenModel.ScreenHeight * differenceInY, 0);
    }
    public void SetPositionOfBackground()
    {
        GameObject.FindGameObjectWithTag("Background").transform.position = new Vector3(0, 0, 0);
    }
}
