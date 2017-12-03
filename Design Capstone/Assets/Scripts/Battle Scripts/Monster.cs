using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {
    public int totalHealth;
    public int health;
    public AudioClip monsterSound;
    public float bpm;

    // Use this for initialization
    void Start () {
        health = totalHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DealDamage(int damage) {
        health -= damage;
        
        if(health <= 0) {
            //Handle monster death
        }
    }

    public float GetHealthPercent() {
        return (float)health / (float)totalHealth;
    }

    public void SetMonsterSound(AudioClip sound) {
        monsterSound = sound;
    }

    public void SetBPM(float bpm) {
        this.bpm = bpm;
    }
}
