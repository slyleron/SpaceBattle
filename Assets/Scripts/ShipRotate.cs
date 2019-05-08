using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipRotate : MonoBehaviour {
    public float rotateSpeed, centerSize;
    Vector2 screenCenter;
    Rigidbody shipBody;
	// Use this for initialization
	void Start () {
        screenCenter = new Vector2(Screen.width / 2,Screen.height / 2);
        shipBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        
        
        if (gameObject.transform.eulerAngles.z > 180 && gameObject.transform.eulerAngles.z <360)
        {
            shipBody.AddRelativeTorque(0, 0, 360-gameObject.transform.eulerAngles.z);
        }
        else if (gameObject.transform.eulerAngles.z < 180 && gameObject.transform.eulerAngles.z > 0)
        {
            shipBody.AddRelativeTorque(0, 0, -gameObject.transform.eulerAngles.z);
        }
        
        //gameObject.transform.Rotate(gameObject.transform.rotation.x, gameObject.transform.rotation.y, 0, Space.World);

        if (Vector2.Distance(Input.mousePosition, screenCenter) > centerSize)
        {
            if (Input.mousePosition.x > screenCenter.x+centerSize/2)
            {
                shipBody.AddRelativeTorque(0, rotateSpeed * (Time.deltaTime* (Input.mousePosition.x - screenCenter.x) / 100), 0);
                
            }
            else if (Input.mousePosition.x < screenCenter.x + centerSize / 2)
            {
                shipBody.AddRelativeTorque(0, -rotateSpeed * (Time.deltaTime * -(Input.mousePosition.x - screenCenter.x) / 100), 0);
                
            }
            if(Input.mousePosition.y > screenCenter.y + centerSize / 2)
            {
                shipBody.AddRelativeTorque(rotateSpeed * (Time.deltaTime * -(Input.mousePosition.y - screenCenter.y) / 100), 0, 0 );
                
            }
            else if(Input.mousePosition.y < screenCenter.y + centerSize / 2)
            {
                shipBody.AddRelativeTorque(-rotateSpeed * (Time.deltaTime * (Input.mousePosition.y - screenCenter.y) / 100), 0, 0 );
                
            }
            

        }
	}
}
