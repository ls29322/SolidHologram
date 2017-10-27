﻿using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour
{

	GameObject player;      //Public variable to store a reference to the player game object


    private Vector3 offset;         //Private variable to store the offset distance between the player and camera

    // Use this for initialization
    void Start()
    {
		
		//Calculate and store the offset value by getting the distance between the player's position and camera's position.
        //offset = transform.position - player.transform.position;
		offset = transform.position;
		print (offset);
	}

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
	/*	if (player == null) {
			//player = GameObject.Find("CharacterRobotBoy(Clone)");
			//player = GameObject.CompareTag ("Player");
			offset = transform.position - player.transform.position;
		} 
		else {
			transform.position = player.transform.position + offset;
		}*/
		if (player != null)
			transform.position = player.transform.position + offset;
    }

	public void setPlayer(GameObject playerPassed) {
		player = playerPassed;
	}
}