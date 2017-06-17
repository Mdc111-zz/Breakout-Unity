using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeighborDestroyer {

    private List<Vector2> neighborCoords;
	private GameObject Brick;
    private ObjectManager objectManager;

	public NeighborDestroyer(GameObject Brick, ObjectManager instance){
        objectManager = instance;
		this.Brick = Brick;
        neighborCoords = new List<Vector2>();
        FindNeighbor();
        DestroyAllNeighbor();

    }

	private void DestroyAllNeighbor(){
        foreach (GameObject Brick in objectManager.brick.bricks.ToArray())
        {
            foreach (Vector2 Coord in neighborCoords.ToArray())
            {
                if (Coord.x == Brick.transform.position.x && Coord.y == Brick.transform.position.y)
                {
					objectManager.brickCollision.EffectOnBrick(Brick);
				}
			}
		}
	}

	private void FindNeighbor(){
		neighborCoords.Add(new Vector2(Brick.transform.position.x + objectManager.brickSettings.BrickWidth, Brick.transform.position.y));
		neighborCoords.Add(new Vector2(Brick.transform.position.x - objectManager.brickSettings.BrickWidth, Brick.transform.position.y));
		neighborCoords.Add(new Vector2(Brick.transform.position.x, Brick.transform.position.y + objectManager.brickSettings.BrickHeight));
		neighborCoords.Add(new Vector2(Brick.transform.position.x, Brick.transform.position.y - objectManager.brickSettings.BrickHeight));
	}

	public static void RunNeighborDestroyer(GameObject Brick, ObjectManager instance)
    {
        new NeighborDestroyer(Brick, instance);
    }
}
