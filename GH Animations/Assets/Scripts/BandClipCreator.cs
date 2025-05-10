using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BandClipCreator : MonoBehaviour
{
    public Animator Anim;
    public string PerfAnim;
    	
	bool escrito = false;
	public string ClipName;
	public float AnimTime = 0f;
	public float StartTime;
	public float EndTime;
	public string CameraName01;
	public string CameraName02;
	public string ik_targetl = "slave";
	public string ik_targetr = "slave";
	public string strum = "false";
	public string fret = "false";
	public string chord = "false";
	//string Checksum;
	public string Band1 = "vocalist";
	public string Band2 = "TRG_Geo_Camera_Performance_SING01";
	public string BandLocation = "vocalist_start";
	public GameObject target;
	
	public bool Test = false;
	public AudioSource audioSource;
	public float delay;
	
	// Start is called before the first frame update
    void Start()
    {
        if(Test){
        audioSource.time = delay;
		audioSource.Play();
		PlayClip();
		}
		
    }

    // Update is called once per frame
    public void CreateClip(PerfExporter Exporter, float seconds,string Checksum){
        if(!escrito){
		Exporter.AddBandClip(ClipName,StartTime,EndTime,PerfAnim,CameraName01,CameraName02,Checksum,Band1,Band2,BandLocation,ik_targetl,ik_targetr,strum,fret,chord);
		escrito = true;
		}
		Exporter.AddTextBandClip(ClipName,seconds,Checksum,StartTime,EndTime);
    }
	
	public void PlayClip(){
				Anim.Play (PerfAnim, 0, AnimTime);
	}
}
