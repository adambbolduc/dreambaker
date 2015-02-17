﻿using UnityEngine;
using System.Collections;

public class MobController : MonoBehaviour {

    private Transform target;
    public int moveSpeed;
    public Vector3 positionOrigin;
    public Quaternion rotationOrigin;
    public float healthBar = 100;
    private GameObject instantiatedObj;
    private GameObject gameController;

    // states of mobs
    private bool moveTowardATarget = false;
    
    void Awake()
    {
        spawnAtOrigin();
        gameController = GameObject.Find("GameController");
    }

    private void spawnAtOrigin(){
        transform.position = this.positionOrigin;
        transform.rotation = this.rotationOrigin;
    }

    // always 
    public void spawnAtOrigin(Vector3 positionOrigin)
    {
        this.positionOrigin = positionOrigin;
        this.rotationOrigin = Quaternion.identity;
        spawnAtOrigin();
    }

    public void trackTarget(Transform target){
        this.target = target;
        moveTowardATarget = true;
    }

    public void untrackTarget()
    {
        this.target = null;
        moveTowardATarget = false;
    }

    public void moveTowardTarget()
    {
        transform.LookAt(target.position);
        moveForward();
    }

    public void moveBackToSpawn()
    {
        transform.LookAt(this.positionOrigin);
        moveForward();
    }

    private void moveForward()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    void FixedUpdate()
    {
        move();
    }

    private void move()
    {
        if (moveTowardATarget)
        {
            moveTowardTarget();
        }
        else
        {
            moveBackToSpawn();
        }
    }

    public void takeDammage(float attackDammage)
    {
        healthBar -= attackDammage;
        if (healthBar == 0)
        {
            gameController.SendMessage("mort", gameObject);
        }
    }


}
