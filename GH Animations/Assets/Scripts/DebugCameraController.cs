using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugCameraController : MonoBehaviour
{
    public GameObject [] CameraListPos;
	public Transform Target;
	public int CurCameraPos;
	public Text CameraCutText;
	//public int NewCameraPos;
	
void LateUpdate(){
	if(Input.GetKeyDown(KeyCode.Alpha1)) {
        ChangeCameraPos(1);
		CameraCutText.text = "Singer CloseUp";
    }
	if(Input.GetKeyDown(KeyCode.Alpha2)) {
        ChangeCameraPos(2);
		CameraCutText.text = "Singer Mocap Temp";
    }
	if(Input.GetKeyDown(KeyCode.Alpha3)) {
        ChangeCameraPos(3);
		CameraCutText.text = "Guitar Close Up";
    }
	if(Input.GetKeyDown(KeyCode.Alpha4)) {
        ChangeCameraPos(4);
		CameraCutText.text = "Solo Guitar";
    }
	if(Input.GetKeyDown(KeyCode.Alpha5)) {
        ChangeCameraPos(5);
		CameraCutText.text = "G Acros Stage";
    }
	if(Input.GetKeyDown(KeyCode.Alpha6)) {
        ChangeCameraPos(6);
		CameraCutText.text = "S Across Stage";
    }
	if(Input.GetKeyDown(KeyCode.Alpha7)) {
        ChangeCameraPos(7);
		CameraCutText.text = "Audience";
    }
	if(Input.GetKeyDown(KeyCode.Alpha8)) {
        ChangeCameraPos(8);
		CameraCutText.text = "Drum Stage";
    }
	if(Input.GetKeyDown(KeyCode.Alpha9)) {
        ChangeCameraPos(9);
		CameraCutText.text = "Bass CloseUp";
    }
	if(Input.GetKeyDown(KeyCode.Alpha0)) {
        ChangeCameraPos(0);
		CameraCutText.text = "Intro";
    }
}
	
	
/*public int GetPressedNumber() {
    for (int number = 0; number <= 9; number++) {
        if (Input.GetKeyDown(number.ToString()))
		    CurCameraPos = number;
			Target.parent = CameraListPos[number].transform;
			Target.localPosition = new Vector3 (0f,0f,0f);
			Target.rotation = CameraListPos[number].transform.rotation;
            return number;
    }

    return -1;
}*/
	
	void ChangeCameraPos(int number){
		CurCameraPos = number;
		Target.parent = CameraListPos[number].transform;
		Target.localPosition = new Vector3 (0f,0f,0f);
		Target.rotation = CameraListPos[number].transform.rotation;
	}
}
