using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle {

    public Vector3 particleEndPosition;
    
    Sprite particleBackground;
    ObjectManager objectManager;

    public Particle(ObjectManager objectManager)
    {
        this.objectManager = objectManager;
    }

    public void setupParticleGameObject(GameObject[] particles, Vector3 BrickPosition)
    {
        for (int i = 0; i < particles.Length; i++)
        {
            particleBackground = Resources.Load<Sprite>("Sprites/BlueBackground");
            Rigidbody2D particlesRigidBody = particles[i].AddComponent<Rigidbody2D>();
            particlesRigidBody.bodyType = RigidbodyType2D.Kinematic;
            SpriteRenderer particleSpriteRenderer = particles[i].AddComponent<SpriteRenderer>();
            particleSpriteRenderer.sprite = particleBackground;
            particles[i].transform.position = BrickPosition;


            float particleWidth = particles[i].GetComponent<SpriteRenderer>().bounds.size.x;
            float particleHeight = particles[i].GetComponent<SpriteRenderer>().bounds.size.y;
            float differenceInX = 1 / particleWidth;
            float differenceInY = 1 / particleHeight;
            particles[i].transform.localScale = new Vector3((objectManager.brickSettings.BrickWidth - 2) * differenceInX, (objectManager.brickSettings.BrickWidth - 2) * differenceInY, 0);
        }
    }

    public void moveParticleRight(GameObject particle)
    {
        particle.transform.Translate(Vector2.right * 2);
    }
    public void moveParticleLeft(GameObject particle)
    {
        particle.transform.Translate(Vector2.left * 2);
    }
    public void moveParticleUp(GameObject particle)
    {
        particle.transform.Translate(Vector3.up * 2);
    }
    public void moveParticleDown(GameObject particle)
    {
        particle.transform.Translate(Vector3.down * 2);
    }
}
