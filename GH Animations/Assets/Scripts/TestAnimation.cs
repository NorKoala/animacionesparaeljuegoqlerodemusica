using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnimation : MonoBehaviour
{
    public Animator Anim;
    public string PerfAnim;
    public float delay;
	public float AnimTime = 0f;
	public AudioSource audioSource;
			
	// Start is called before the first frame update
    void Start()
    {
        audioSource.time = delay;
		audioSource.Play();
		Anim.Play (PerfAnim, 0, AnimTime);
    }

}
