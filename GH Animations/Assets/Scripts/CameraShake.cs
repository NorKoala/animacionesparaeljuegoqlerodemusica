using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
    {
	public Transform camTransform;
	// Amplitude of the shake. A larger value shakes the camera harder.
	public float shakeAmount = 0.002f;
	public bool Shake = false;
	
	Vector3 originalPos;
	
	void Awake()
	{
		if (camTransform == null)
		{
			camTransform = GetComponent(typeof(Transform)) as Transform;
		}
	}
	
	void OnEnable()
	{
		originalPos = camTransform.localPosition;
		Shake = true;
	}

	void Update()
	{
	//if(camTransform && Shake)camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
	if(camTransform && Shake)camTransform.localPosition = new Vector3(Mathf.PerlinNoise(0, Time.time) * 2 - 1, 0, 0) * shakeAmount;
	}
}
