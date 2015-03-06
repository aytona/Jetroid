﻿using UnityEngine;
using System.Collections;

public class AlienB : MonoBehaviour {

	private Animator animator;
	private bool readyToAttack;
	public AudioClip attackSound;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D (Collider2D target) {
		if (target.gameObject.tag == "Player") {
			if (readyToAttack) {
				var explode = target.GetComponent<Explode>() as Explode;
				explode.OnExplode();
			}
			else {
				animator.SetInteger ("AnimState", 1);
				if(attackSound) {
					AudioSource.PlayClipAtPoint(attackSound, transform.position);
				}
			}
		}
	}

	void OnTriggerExit2D (Collider2D target) {
		readyToAttack = false;
		animator.SetInteger ("AnimState", 0);
	}

	void Attack() {
		readyToAttack = true;
	}
}
