using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform player;

    // Update is called once per frame
    void LateUpdate () {
        if(player)transform.position = player.transform.position + new Vector3(0, 0, 0);
    }
	
	public void ChangeOrigin (Transform NewPlayer ){
        player = NewPlayer;
	}
}
