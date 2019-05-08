using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour {
    public float rotateSpeed;
    Transform playerTranform;
	// Use this for initialization
	void Start () {
        playerTranform = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //Transform updatedPlayer= playerTranform.Rotate(playerTranform.rotation.x, playerTranform.rotation.y, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, playerTranform.rotation, rotateSpeed * Time.deltaTime);
	}
}
