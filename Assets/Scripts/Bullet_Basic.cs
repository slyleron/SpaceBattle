using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Basic : MonoBehaviour {
    public Rigidbody bulletBody;
    public float lifeTime = 0;
	// Use this for initialization
	public void Initiate (float power,float newLifeTime) {
        lifeTime = newLifeTime;
        bulletBody.AddRelativeForce(0, 0, power, ForceMode.Impulse);
        StartCoroutine("Timer");
	}
	
	IEnumerator Timer()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        //search and destroy 
        if (other.tag == "Enemy")
        {
            gameObject.transform.LookAt(other.transform);
            var locVel = transform.InverseTransformDirection(bulletBody.velocity);
            bulletBody.velocity = new Vector3(0, 0, 0);
            bulletBody.velocity += transform.forward * locVel.z;
        }
    }
}
