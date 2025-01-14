using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDeCamaraAutomatica : MonoBehaviour
{
    public Transform Target;
	public float Distance;
	public float lookAtDistance  = 10.0f;
	public float Damping = 6.0f;
	public float time = 0.0f;
	bool Permiso = false;
	public bool Destruir = false;
	public float DestroyTime = 0.0f;
	
	IEnumerator Start (){
		yield return new WaitForSeconds (time);
		Permiso = true;
		yield return new WaitForSeconds (DestroyTime);
		if (Destruir) Destroy(this);
	}
	
    void Update()
    {
	if (Target && Permiso){
    Distance = Vector3.Distance(Target.position, transform.position);
    Quaternion rotation = Quaternion.LookRotation(Target.position - transform.position);
	transform.rotation = Quaternion.Slerp(transform.rotation, rotation , Time.deltaTime * Damping);
	}
    }
}
