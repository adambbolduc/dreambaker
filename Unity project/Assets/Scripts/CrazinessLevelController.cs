﻿using UnityEngine;
using System.Collections;

public class CrazinessLevelController : MonoBehaviour {

    //private System.Collections.Generic.List<spawnArea> spawnAreaList;
    public float TIME_TO_RAISE_CRAYZYNESS_LEVEL = 3;
    public float crazinessLevel = 0.0F;
    public UnityEngine.UI.Slider crazynessLevelSlider;


    private Spawner[] spawnAreaList;
    private GameController gameController;
    private Timer timer;

    // crazynesslevelslider chercher du UI


	// Use this for initialization
	void Start () {


        spawnAreaList = FindObjectsOfType(typeof(Spawner)) as Spawner[];
        timer = gameObject.AddComponent<Timer>();
        timer.timerValue = TIME_TO_RAISE_CRAYZYNESS_LEVEL;
        timer.trigger = this;
        timer.startTimer();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    private void signalCrazinessLevelToSpawner()
    {
        foreach (Spawner spawner in spawnAreaList)
        {
            spawner.setCrazinessLevel(crazinessLevel);
        }        
    }

    public void timesUp()
    {
        incrementCrazinessLevel();
        timer.startTimer();
        displayCrazynessValue();
        signalCrazinessLevelToSpawner();
    }

    private void incrementCrazinessLevel()
    {
        if( crazinessLevel < 100){
            crazinessLevel = crazinessLevel + 1.0F;
        }
    }

    private void displayCrazynessValue()
    {
        crazynessLevelSlider.value = crazinessLevel;
    }


}