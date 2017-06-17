using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick  {

    private float xCoord;
    private float yCoord;
    private float width;
    private float height;
    public int brickScore;
    private GameObject brick;
    ObjectManager objectManager;
    public List<GameObject> bricks;
    Sprite brickBackground;

    public Brick(ObjectManager instance)
    {
        bricks = new List<GameObject>();
        objectManager = instance;
        brickScore = 50;
    }


    public void CreateBrick(float xCoord, float yCoord)
    {
        brick = new GameObject();
        brickBackground = Resources.Load<Sprite>("Sprites/WhiteBackground");
        Rigidbody2D brickRigidBody = brick.AddComponent<Rigidbody2D>();
        brickRigidBody.bodyType = RigidbodyType2D.Kinematic;
        SpriteRenderer brickSpriteRenderer = brick.AddComponent<SpriteRenderer>();
        brickSpriteRenderer.sprite = brickBackground;

        float brickWidth = brick.GetComponent<SpriteRenderer>().bounds.size.x;
        float brickHeight = brick.GetComponent<SpriteRenderer>().bounds.size.y;
        float differenceInX = 1 / brickWidth;
        float differenceInY = 1 / brickHeight;
        brick.transform.localScale = new Vector3((objectManager.brickSettings.BrickWidth - 2) * differenceInX, (objectManager.brickSettings.BrickHeight - 2) * differenceInY, 0);
        brick.transform.position = new Vector3(xCoord, yCoord, -1);

        bricks.Add(brick);
    }
}
