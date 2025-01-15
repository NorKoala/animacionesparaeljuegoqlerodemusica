using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PerfExporter : MonoBehaviour
{
    // Path to the file
    public string filePath;

    private void Start()
    {
        // Set the file path relative to the persistent data path
        //filePath = Path.Combine(Application.persistentDataPath, "Performance.txt");

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
		
        //Debug.Log("Added text: " + text);
		/*Debug.Log("{");
        Debug.Log("   time = 183000");
        Debug.Log("    scr = Band_PlayLoop");
        Debug.Log("    params = {");
        Debug.Log("         name = guitarist");
        Debug.Log("         Male = Guit_Greg_NoTempo_02");
        Debug.Log("         Female = Guit_Greg_NoTempo_02_F");
        Debug.Log("        }");
        Debug.Log("},");*/
		Debug.Log("Added Performance: " + System.DateTime.Now);
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
