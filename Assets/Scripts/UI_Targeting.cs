using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Targeting : MonoBehaviour {
    private float screenX, screenY;
    private void Start()
    {
        screenX = Screen.width / 2;
        screenY = Screen.height / 2;
    }

    // Update is called once per frame
    void Update () {
        transform.localPosition = new Vector2(Input.mousePosition.x-screenX,Input.mousePosition.y-screenY);
	}
}
