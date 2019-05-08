using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour {

    public float moveSpeed, fastSpeed, boostExtra;
    Rigidbody myBody;
	// Use this for initialization
	void Start () {
        myBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 moveVector = new Vector3(Input.GetAxis("Horizontal") * fastSpeed * Time.deltaTime, 0, Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime);
        myBody.AddRelativeForce(moveVector, ForceMode.Force);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            myBody.AddRelativeForce(0, 0, boostExtra * Time.deltaTime, ForceMode.Force);
            GameObject.Find("Speed").GetComponent<Text>().text = "Left booster++ = " + myBody.velocity.magnitude.ToString();
            
        }
        else GameObject.Find("Speed").GetComponent<Text>().text = "Left booster = " + myBody.velocity.magnitude.ToString();
    }
}
