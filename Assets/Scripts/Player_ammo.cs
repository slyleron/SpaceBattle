using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_ammo : MonoBehaviour {
    public int currentAmmo, maxAmmo,mouseButton=0;
    public float maxSpread, fireSpread,fireSpeed, firePower,bulletLife;
    public GameObject bullet;
    public bool clickShot;
    public  Transform[] barrel;
	// Use this for initialization
	void Start () {
        currentAmmo = 100;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(mouseButton))
        {
            if (clickShot)
            {
                Shot();
            }
            else
            {
                StartCoroutine("Delay");
            }
        }
        else if (Input.GetMouseButtonUp(mouseButton))
        {
            StopCoroutine("Delay");
        }
	}
    void Shot()
    {
        for (int i = 0; i < barrel.Length; i++) {
            GameObject temp = Instantiate(bullet, barrel[i].transform.position, barrel[i].transform.rotation) as GameObject;
            //change direction a little bit

            Vector3 randomDirection = new Vector3(Random.Range(-fireSpread, fireSpread), Random.Range(-maxSpread, maxSpread), Random.Range(-maxSpread, maxSpread));
            Vector3 mainDirection = Camera.main.ScreenPointToRay(Input.mousePosition).GetPoint(30);
            temp.transform.rotation = Quaternion.LookRotation((mainDirection + randomDirection) - temp.transform.position, Vector3.up);
            temp.GetComponent<Bullet_Basic>().Initiate(firePower, bulletLife);
            currentAmmo--;
            GameObject.Find("AmmoText").GetComponent<Text>().text = "Ammo "+currentAmmo.ToString();
        }
        StartCoroutine("Delay");
        
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(fireSpeed);
        Shot();
    }
}
