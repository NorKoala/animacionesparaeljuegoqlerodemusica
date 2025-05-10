using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PerfExporter : MonoBehaviour
{
    // Path to the file
    public string filePath;
	public string SongScriptfilePath;
	public PerformanceValues PerfMaster;
	public GameObject PerfExportSuccess;
	
    private void Start()
    {
        // Set the file path relative to the persistent data path
        //filePath = Path.Combine(Application.persistentDataPath, "Performance.txt");
		PerfMaster = GetComponent<PerformanceValues>();
		
        // Optionally, create the file if it doesn't exist
        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, "Log File Created\n");
        }
        
        Debug.Log("File path: " + filePath);
    }

    // Method to add text to the file
    /*public void AddText(string text)
    {
        // Append text to the file with a new line
        File.AppendAllText(filePath, text + "\n");
        Debug.Log("Added text: " + text);
    }*/
	
	public void AddCheksum (string text){
					/*using (var FileWriter = new StreamWriter("YOUR_FILE_NAME.txt", false)){
					FileWriter.WriteLine(text + "_performance = [");
					}*/
		
		//File.AppendAllText(filePath, text + "_performance = [" + "\n");
		File.WriteAllText(filePath, text + "_performance = [" + "\n");
		//File.WriteLine(text + " = [");
	}
	public void AddEnding (){
		File.AppendAllText(filePath,"]" + "\n");
		//File.WriteLine(text + " = [");
		Debug.Log("Performance File Exported at : " + System.DateTime.Now);
		PerfExportSuccess.SetActive(true);
	}
	
    public void AddTextFacial(string name,float seconds,string Anim)
    {
        // Append text to the file with a new line
        //File.AppendAllText(filePath, text + "\n");
		int milliseconds = Mathf.RoundToInt(seconds * 1000);
		string convertedString = milliseconds.ToString();
		File.AppendAllText(filePath, "{" + "\n");
		File.AppendAllText(filePath, "   time = " + convertedString + "\n");
		File.AppendAllText(filePath, "    scr = Band_PlayFacialAnim" + "\n");
		File.AppendAllText(filePath, "    params = {" + "\n");
		File.AppendAllText(filePath, "         name = " + name + "\n");
		File.AppendAllText(filePath, "         anim = " + Anim + "\n");
		File.AppendAllText(filePath, "        }" + "\n");
		File.AppendAllText(filePath, "}," + "\n");
		Debug.Log("Added FacialAnims: " + System.DateTime.Now);
    }
	
    /*public void AddTextBandClip(string name,float seconds,string Anim)
    {
        // Append text to the file with a new line
		int milliseconds = Mathf.RoundToInt(seconds * 1000);
		string convertedString = milliseconds.ToString();
		File.AppendAllText(filePath, "{" + "\n");
		File.AppendAllText(filePath, "   time = " + convertedString + "\n");
		File.AppendAllText(filePath, "    scr = Band_PlayClip" + "\n");
		File.AppendAllText(filePath, "    params = {" + "\n");
		File.AppendAllText(filePath, "         clip = " + name + "_" + Anim + "\n");
		File.AppendAllText(filePath, "         startframe  = 1" + "\n");
		File.AppendAllText(filePath, "         endframe = 200" + "\n");
		File.AppendAllText(filePath, "         timefactor = 1" + "\n");
		File.AppendAllText(filePath, "        }" + "\n");
		File.AppendAllText(filePath, "}," + "\n");
		Debug.Log("Added Band_PlayIdle: " + System.DateTime.Now);
    }*/
	
	public void AddTextBandClip(string name,float seconds,string checksum,float startframe,float endframe)
    {
        // Append text to the file with a new line
		int milliseconds = Mathf.RoundToInt(seconds * 1000);
		string convertedString = milliseconds.ToString();
		
		milliseconds = Mathf.RoundToInt(startframe * 30);
		string convertedString1 = milliseconds.ToString();
		
		milliseconds = Mathf.RoundToInt(endframe * 30);
		string convertedString2 = milliseconds.ToString();
		
		File.AppendAllText(filePath, "{" + "\n");
		File.AppendAllText(filePath, "   time = " + convertedString + "\n");
		File.AppendAllText(filePath, "    scr = Band_PlayClip" + "\n");
		File.AppendAllText(filePath, "    params = {" + "\n");
		File.AppendAllText(filePath, "         clip = " + checksum + "_" + name + "\n");
		File.AppendAllText(filePath, "			startframe = " + convertedString1 + "\n");
		File.AppendAllText(filePath, "			endframe = " + convertedString2 + "\n");
		File.AppendAllText(filePath, "         timefactor = 1" + "\n");
		File.AppendAllText(filePath, "        }" + "\n");
		File.AppendAllText(filePath, "}," + "\n");
		Debug.Log("Added Band_PlayClip: " + System.DateTime.Now);
    }
	
    public void AddTextPlayIdle(string name,float seconds,string Anim)
    {
        // Append text to the file with a new line
		int milliseconds = Mathf.RoundToInt(seconds * 1000);
		string convertedString = milliseconds.ToString();
		File.AppendAllText(filePath, "{" + "\n");
		File.AppendAllText(filePath, "   time = " + convertedString + "\n");
		File.AppendAllText(filePath, "    scr = Band_PlayIdle" + "\n");
		File.AppendAllText(filePath, "    params = {" + "\n");
		File.AppendAllText(filePath, "         name = " + Anim + "\n");
		File.AppendAllText(filePath, "         no_id = restart" + "\n");
		File.AppendAllText(filePath, "        }" + "\n");
		File.AppendAllText(filePath, "}," + "\n");
		Debug.Log("Added FacialAnims: " + System.DateTime.Now);
    }
	
    public void AddText(string name,float seconds,string Anim)
    {
        // Append text to the file with a new line
        //File.AppendAllText(filePath, text + "\n");
		int milliseconds = Mathf.RoundToInt(seconds * 1000);
		string convertedString = milliseconds.ToString();
		File.AppendAllText(filePath, "{" + "\n");
		File.AppendAllText(filePath, "   time = " + convertedString + "\n");
		File.AppendAllText(filePath, "    scr = Band_PlayLoop" + "\n");
		File.AppendAllText(filePath, "    params = {" + "\n");
		File.AppendAllText(filePath, "         name = " + name + "\n");
		File.AppendAllText(filePath, "         Male = " + Anim + "\n");
		File.AppendAllText(filePath, "         Female = " + Anim + "\n");
		File.AppendAllText(filePath, "        }" + "\n");
		File.AppendAllText(filePath, "}," + "\n");
		Debug.Log("Added Performance: " + System.DateTime.Now);
    }
	
	
	
    public void AddBandClip(string name,float startframe,float endframe,string Anim,string CameraName01,string CameraName02,string checksum,string Band1,string Band2,string BandLocation,string ik_targetl,string ik_targetr,string strum,string fret,string chord)
    {
		int milliseconds = Mathf.RoundToInt(startframe * 30);
		string convertedString = milliseconds.ToString();
		
		milliseconds = Mathf.RoundToInt(endframe * 30);
		string convertedString2 = milliseconds.ToString();
		
		File.AppendAllText(SongScriptfilePath, checksum + "_" + name + " = {" + "\n");
		File.AppendAllText(SongScriptfilePath, "   dataformat = 2" + "\n");
		File.AppendAllText(SongScriptfilePath, "   characters = [" + "\n");
		File.AppendAllText(SongScriptfilePath, "        {" + "\n");
		File.AppendAllText(SongScriptfilePath, "            name = " + Band1 + "\n");
		File.AppendAllText(SongScriptfilePath, "			startnode = " + BandLocation + "\n");
		File.AppendAllText(SongScriptfilePath, "			anim = " + Anim + "\n");
		File.AppendAllText(SongScriptfilePath, "			startframe = " + convertedString + "\n");
		File.AppendAllText(SongScriptfilePath, "			endframe = " + convertedString2 + "\n");
		File.AppendAllText(SongScriptfilePath, "			timefactor = 1" + "\n");
		File.AppendAllText(SongScriptfilePath, "			ik_targetl = " + ik_targetl + "\n");
		File.AppendAllText(SongScriptfilePath, "			ik_targetr = " + ik_targetr + "\n");
		File.AppendAllText(SongScriptfilePath, "			strum = " + strum + "\n");
		File.AppendAllText(SongScriptfilePath, "			fret = " + fret + "\n");
		File.AppendAllText(SongScriptfilePath, "			chord = " + chord + "\n");
		File.AppendAllText(SongScriptfilePath, "        }" + "\n");
		File.AppendAllText(SongScriptfilePath, "   ]" + "\n");
		File.AppendAllText(SongScriptfilePath, "   cameras = [" + "\n");
		File.AppendAllText(SongScriptfilePath, "        {" + "\n");
		File.AppendAllText(SongScriptfilePath, "			slot = 0" + "\n");
		File.AppendAllText(SongScriptfilePath, "			name = " + Band2 + "\n");
		File.AppendAllText(SongScriptfilePath, "			anim = " + CameraName01 + "\n");
		File.AppendAllText(SongScriptfilePath, "        }" + "\n");
		File.AppendAllText(SongScriptfilePath, "        {" + "\n");
		File.AppendAllText(SongScriptfilePath, "			slot = 1" + "\n");
		File.AppendAllText(SongScriptfilePath, "			name = " + Band2 + "\n");
		File.AppendAllText(SongScriptfilePath, "			anim = " + CameraName02 + "\n");
		File.AppendAllText(SongScriptfilePath, "        }" + "\n");
		File.AppendAllText(SongScriptfilePath, "   ]" + "\n");
		File.AppendAllText(SongScriptfilePath, " }" + "\n");	
		
		Debug.Log("Added BandClipData: " + System.DateTime.Now);
    }


    public void AddSongScriptIntro(string text)
    {
        // Append text to the file with a new line
		File.WriteAllText(SongScriptfilePath, " car_female_anim_struct_" + text + " = {" + "\n");
		File.AppendAllText(SongScriptfilePath, "	guitar = {" + "\n");
		File.AppendAllText(SongScriptfilePath, "		pak = L_GUIT_Ginger_Bulls_anims" + "\n");
		File.AppendAllText(SongScriptfilePath, "		anim_set = L_GUIT_Ginger_Bulls_anims_set" + "\n");
		File.AppendAllText(SongScriptfilePath, "		finger_anims = guitarist_finger_anims_car_female" + "\n");
		File.AppendAllText(SongScriptfilePath, "		fret_anims = fret_anims_rocker" + "\n");
		File.AppendAllText(SongScriptfilePath, "		strum_anims = CAR_Female_Normal" + "\n");
		File.AppendAllText(SongScriptfilePath, "		facial_anims = facial_anims_female_rocker" + "\n");
		File.AppendAllText(SongScriptfilePath, "	}" + "\n");
		File.AppendAllText(SongScriptfilePath, "	Bass = {" + "\n");
		File.AppendAllText(SongScriptfilePath, "		pak = L_GUIT_Judita_Bulls_anims" + "\n");
		File.AppendAllText(SongScriptfilePath, "		anim_set = L_GUIT_Judita_Bulls_anims_set" + "\n");
		File.AppendAllText(SongScriptfilePath, "		finger_anims = guitarist_finger_anims_car_female" + "\n");
		File.AppendAllText(SongScriptfilePath, "		fret_anims = fret_anims_rocker" + "\n");
		File.AppendAllText(SongScriptfilePath, "		strum_anims = CAR_Female_Normal" + "\n");
		File.AppendAllText(SongScriptfilePath, "		facial_anims = facial_anims_female_rocker" + "\n");
		File.AppendAllText(SongScriptfilePath, "	}" + "\n");
		File.AppendAllText(SongScriptfilePath, "	drum = {" + "\n");
		File.AppendAllText(SongScriptfilePath, "		pak = L_DRUM_Loops_Standard_anims" + "\n");
		File.AppendAllText(SongScriptfilePath, "		anim_set = l_drum_loops_standard_anims_set" + "\n");
		File.AppendAllText(SongScriptfilePath, "		facial_anims = facial_anims_female_rocker" + "\n");
		File.AppendAllText(SongScriptfilePath, "	}" + "\n");
		File.AppendAllText(SongScriptfilePath, "	vocals = {" + "\n");
		File.AppendAllText(SongScriptfilePath, "		pak = L_SING_Amanda_Bulls_anims" + "\n");
		File.AppendAllText(SongScriptfilePath, "		anim_set = L_SING_Amanda_Bulls_anims_set" + "\n");
		File.AppendAllText(SongScriptfilePath, "		facial_anims = facial_anims_female_rocker" + "\n");
		File.AppendAllText(SongScriptfilePath, "	}" + "\n");
		File.AppendAllText(SongScriptfilePath, "}" + "\n");
		File.AppendAllText(SongScriptfilePath, "car_male_anim_struct_" + text + " = {" + "\n");
		File.AppendAllText(SongScriptfilePath, "	guitar = {" + "\n");
		File.AppendAllText(SongScriptfilePath, "		pak = L_GUIT_Matt_Bulls_anims" + "\n");
		File.AppendAllText(SongScriptfilePath, "		anim_set = L_GUIT_Matt_Bulls_anims_set" + "\n");
		File.AppendAllText(SongScriptfilePath, "		finger_anims = guitarist_finger_anims_CAR_Male" + "\n");
		File.AppendAllText(SongScriptfilePath, "		fret_anims = fret_anims_rocker" + "\n");
		File.AppendAllText(SongScriptfilePath, "		strum_anims = CAR_Male_Normal" + "\n");
		File.AppendAllText(SongScriptfilePath, "		facial_anims = facial_anims_male_rocker" + "\n");
		File.AppendAllText(SongScriptfilePath, "	}" + "\n");
		File.AppendAllText(SongScriptfilePath, "	Bass = {" + "\n");
		File.AppendAllText(SongScriptfilePath, "		pak = L_GUIT_Davidicus_Bulls_anims" + "\n");
		File.AppendAllText(SongScriptfilePath, "		anim_set = L_GUIT_Davidicus_Bulls_anims_set" + "\n");
		File.AppendAllText(SongScriptfilePath, "		finger_anims = guitarist_finger_anims_CAR_Male" + "\n");
		File.AppendAllText(SongScriptfilePath, "		fret_anims = fret_anims_rocker" + "\n");
		File.AppendAllText(SongScriptfilePath, "		strum_anims = CAR_Male_Normal" + "\n");
		File.AppendAllText(SongScriptfilePath, "		facial_anims = facial_anims_male_rocker" + "\n");
		File.AppendAllText(SongScriptfilePath, "	}" + "\n");
		File.AppendAllText(SongScriptfilePath, "	drum = {" + "\n");
		File.AppendAllText(SongScriptfilePath, "		pak = L_DRUM_Loops_Standard_anims" + "\n");
		File.AppendAllText(SongScriptfilePath, "		anim_set = l_drum_loops_standard_anims_set" + "\n");
		File.AppendAllText(SongScriptfilePath, "		facial_anims = facial_anims_male_rocker" + "\n");
		File.AppendAllText(SongScriptfilePath, "	}" + "\n");
		File.AppendAllText(SongScriptfilePath, "	vocals = {" + "\n");
		File.AppendAllText(SongScriptfilePath, "		pak = L_SING_Patrick_Bulls_anims" + "\n");
		File.AppendAllText(SongScriptfilePath, "		anim_set = L_SING_Patrick_Bulls_anims_set" + "\n");
		File.AppendAllText(SongScriptfilePath, "		facial_anims = facial_anims_male_rocker" + "\n");
		File.AppendAllText(SongScriptfilePath, "	}" + "\n");
		File.AppendAllText(SongScriptfilePath, "}" + "\n");
		Debug.Log("Added SongScriptStartValues: " + System.DateTime.Now);
    }





    // Example usage
    /*private void Update()
    {
        // Press the space bar to write to the file
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddText("Space bar pressed at " + System.DateTime.Now);
        }
    }*/
}
