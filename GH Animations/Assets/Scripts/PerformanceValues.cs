using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PerformanceValues : MonoBehaviour
{
    public BandManager Band;
	public PerfExporter Exporter;
	//public PerfExporter BandClipsCreator;
	public Text SingAnimText;
	public AudioSource audioSource;
	//public string checksum;
	
	public Text timeText; // Assign a UI Text element in the Inspector
    private float elapsedTime = 0f;
	
	
	void Update()
    {
        elapsedTime += Time.deltaTime;
        //timeText.text = "Time: " + elapsedTime.ToString("F2") + " seconds";
		timeText.text = elapsedTime.ToString("F2");
    }
	
}
