using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeighborHorizontalDestroyerAnim : Animation
{
    Vector3 BrickPosition;
    Sprite particleBackground;
    Particle particleInstance;
    ObjectManager objectManager;

    public NeighborHorizontalDestroyerAnim(Vector3 BrickPosition, ObjectManager objectManager)
    {
        this.BrickPosition = BrickPosition;
        this.objectManager = objectManager;
        particleInstance = new Particle(objectManager);
        particles = new GameObject[2];

		particles[0] = new GameObject();		
		particles[1] = new GameObject();
        particleInstance.setupParticleGameObject(particles, BrickPosition);
        Register();
    }
    private void Register()
    {
        objectManager.activeAnimations.Add(this);
    }

    private void Unregister()
    {
        objectManager.activeAnimations.Remove(this);
    }
    void moveParticleAnimation()
    {
        particleInstance.moveParticleRight(particles[0]);
        particleInstance.moveParticleLeft(particles[1]);
    }
    
    public override bool IsFinished()
    {
        if (particles[0].transform.position.x >= (BrickPosition.x + objectManager.brickSettings.BrickWidth*5))
            return true;
        return false;
    }

    public override void CycleAnimation()
    {
        if (IsFinished())
        {
            Unregister();
            for (int i = 0; i < particles.Length; i++)
            {
                particles[i].SetActive(false);

            }
        }
        else
        {
            moveParticleAnimation();
        }
    }
}
