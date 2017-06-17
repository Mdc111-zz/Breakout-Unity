using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour{

    public BrickSettings brickSettings;
    public ScreenModel screenModel;
    public GameBall gameBall;
    public GameBat gameBat;
    public GameScore gameScore;
    public BackgroundSize backgroundSize;
    public BrickSpawner brickSpawner;
    public Brick brick;
    public BrickCollision brickCollision;
    public List<Animation> activeAnimations;
    public ScoreFile scoreFile;
    public ScoreUI scoreUI;

    void Awake () {
        activeAnimations = new List<Animation>();

        brickSettings = new BrickSettings(this);
        screenModel = new ScreenModel(this);
        scoreFile = new ScoreFile(this);
        gameScore = new GameScore(this);
        gameBall = new GameBall(this);
        gameBat = new GameBat(this);
        backgroundSize = new BackgroundSize(this);
        brickSpawner = new BrickSpawner(this);
        brick = new Brick(this);
        brickCollision = new BrickCollision(this);
        scoreUI = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreUI>();
        scoreUI.setObjectManager(this);
        scoreUI.setupScoreUI();
    }

    void Start()
    {
        brickSpawner.generateLineOfBricks();
    }
    void Update()
    {
        gameBat.MoveBat();
        gameBall.MoveBall();

        if(gameBall.Ball.transform.position.y < -280)
            gameBall.checkCollisionWithBat();
        gameBall.CollisionWithBoarder();

        if (brickSpawner.CheckBrickLocation())
            scoreFile.WriteToFile();
        else
            brickSpawner.spawnTimerForBricks();

        brickCollision.CheckCollision();
        

        foreach (Animation activeAnimation in activeAnimations.ToArray())
        {
            activeAnimation.CycleAnimation();
        }
    }

    public void deleteInactiveGameObjects(GameObject Brick)
    {
        brick.bricks.Remove(Brick);
        Destroy(Brick);
    }
}
