using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif


namespace UnityStandardAssets.Utility
{
public class PerformanceManager : MonoBehaviour
{
    //public BandManager Band;
	public string checksum;
	public bool WritePerformance;
	/*public bool WriteCheckSum;
	public bool BuildSingPerformance;
	public bool BuildGuitPerformance;
	public bool BuildBassPerformance;
	public bool BuildFacialPerformance;*/
	/*public PerfExporter Exporter;
	public Text SingAnimText;*/
		//public Animator [] Band;
    /*public Animator BassAnim;
	public Animator GuitarAnim;
	public Animator SingerAnim;*/
	PerformanceValues PerfMaster;
		
		public enum Action
        {
            AnimateSing,
			AnimateGuitar,
			AnimateBassist,
			AnimateFacial,
			AnimatePlayClip,
			AnimatePlayIdle,
			//Activate,
            //Deactivate,
            Call,
        }


        [Serializable]
        public class Entry
        {
            //public Animator target;
            public string PerfAnim;
			public Action action;
            public float delay;
        }


        [Serializable]
        public class Entries
        {
            public Entry[] entries;
        }
        
        
        public Entries entries = new Entries();

        
        private void Awake()
        {
			PerfMaster = GetComponent<PerformanceValues>();
            if(WritePerformance){
				
				PerfMaster.Exporter.AddCheksum(checksum);
				}
			foreach (Entry entry in entries.entries)
            {
                switch (entry.action)
                {
                    case Action.AnimateSing:
                        StartCoroutine(AnimateSing(entry));
                        break;                    
					case Action.AnimateGuitar:
                        StartCoroutine(AnimateGuitar(entry));
                        break;
					case Action.AnimateBassist:
                        StartCoroutine(AnimateBassist(entry));
                        break;
					case Action.AnimateFacial:
                        StartCoroutine(AnimateFacial(entry));
                        break;
					case Action.AnimatePlayClip:
                        StartCoroutine(AnimatePlayClip(entry));
                        break;
					case Action.AnimatePlayIdle:
                        StartCoroutine(AnimatePlayIdle(entry));
                        break;
                }
            }
			if(WritePerformance)PerfMaster.Exporter.AddEnding();
        }


        private IEnumerator AnimateSing(Entry entry)
        {
            if(WritePerformance)PerfMaster.Exporter.AddText("vocalist",entry.delay,entry.PerfAnim);
			yield return new WaitForSeconds(entry.delay);
            //entry.target.SetActive(true);
			//SingerAnim.runtimeAnimatorController = PerfAnim[entry];
			PerfMaster.Band.SingerAnim.Play (entry.PerfAnim, 0, 0f);
			PerfMaster.SingAnimText.text = entry.PerfAnim;
        }
		
        private IEnumerator AnimateGuitar(Entry entry)
        {
            if(WritePerformance)PerfMaster.Exporter.AddText("guitarist",entry.delay,entry.PerfAnim);
			yield return new WaitForSeconds(entry.delay);
            //entry.target.SetActive(true);
			PerfMaster.Band.GuitarAnim.Play (entry.PerfAnim, 0, 0f);
        }

        private IEnumerator AnimateBassist(Entry entry)
        {
            if(WritePerformance)PerfMaster.Exporter.AddText("bassist",entry.delay,entry.PerfAnim);
			yield return new WaitForSeconds(entry.delay);
            //entry.target.SetActive(true);
			PerfMaster.Band.BassAnim.Play (entry.PerfAnim, 0, 0f);
        }
        private IEnumerator AnimateFacial(Entry entry)
        {
            if(WritePerformance)PerfMaster.Exporter.AddTextFacial("vocalist",entry.delay,entry.PerfAnim);
			yield return new WaitForSeconds(entry.delay);
            //entry.target.SetActive(true);
			//PerfMaster.Band.BassAnim.Play (entry.PerfAnim, 0, 0f);
        }
		private IEnumerator AnimatePlayClip(Entry entry)
        {
            if(WritePerformance)PerfMaster.Exporter.AddTextBandClip(checksum,entry.delay,entry.PerfAnim);
			yield return new WaitForSeconds(entry.delay);
            //entry.target.SetActive(true);
			//PerfMaster.Band.BassAnim.Play (entry.PerfAnim, 0, 0f);
        }
		private IEnumerator AnimatePlayIdle(Entry entry)
        {
            if(WritePerformance)PerfMaster.Exporter.AddTextPlayIdle("vocalist",entry.delay,entry.PerfAnim);
			yield return new WaitForSeconds(entry.delay);
            //entry.target.SetActive(true);
			//PerfMaster.Band.BassAnim.Play (entry.PerfAnim, 0, 0f);
        }
    }
}

namespace UnityStandardAssets.Utility.Inspector
{
#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof (PerformanceManager.Entries))]
    public class EntriesDrawer : PropertyDrawer
    {
        private const float k_LineHeight = 18;
        private const float k_Spacing = 4;


        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            float x = position.x;
            float y = position.y;
            float width = position.width;

            // Draw label
            EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            // Don't make child fields be indented
            var indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            var entries = property.FindPropertyRelative("entries");

            if (entries.arraySize > 0)
            {
                float actionWidth = .25f*width;
                float PerfAnimWidth = .6f*width;
                float delayWidth = .1f*width;
                float buttonWidth = .05f*width;

                for (int i = 0; i < entries.arraySize; ++i)
                {
                    y += k_LineHeight + k_Spacing;

                    var entry = entries.GetArrayElementAtIndex(i);

                    float rowX = x;

                    // Calculate rects
                    Rect actionRect = new Rect(rowX, y, actionWidth, k_LineHeight);
                    rowX += actionWidth;

                    Rect PerfAnimRect = new Rect(rowX, y, PerfAnimWidth, k_LineHeight);
                    rowX += PerfAnimWidth;

                    Rect delayRect = new Rect(rowX, y, delayWidth, k_LineHeight);
                    rowX += delayWidth;

                    Rect buttonRect = new Rect(rowX, y, buttonWidth, k_LineHeight);
                    rowX += buttonWidth;

                    // Draw fields - passs GUIContent.none to each so they are drawn without labels

                        EditorGUI.PropertyField(actionRect, entry.FindPropertyRelative("action"), GUIContent.none);
                        //EditorGUI.PropertyField(targetRect, entry.FindPropertyRelative("target"), GUIContent.none);
					EditorGUI.PropertyField(PerfAnimRect, entry.FindPropertyRelative("PerfAnim"), GUIContent.none);	
                    EditorGUI.PropertyField(delayRect, entry.FindPropertyRelative("delay"), GUIContent.none);
                    if (GUI.Button(buttonRect, "-"))
                    {
                        entries.DeleteArrayElementAtIndex(i);
                        break;
                    }
                }
            }
            
            // add & sort buttons
            y += k_LineHeight + k_Spacing;

            var addButtonRect = new Rect(position.x + position.width - 120, y, 60, k_LineHeight);
            if (GUI.Button(addButtonRect, "Add"))
            {
                entries.InsertArrayElementAtIndex(entries.arraySize);
            }

            var sortButtonRect = new Rect(position.x + position.width - 60, y, 60, k_LineHeight);
            if (GUI.Button(sortButtonRect, "Sort"))
            {
                bool changed = true;
                while (entries.arraySize > 1 && changed)
                {
                    changed = false;
                    for (int i = 0; i < entries.arraySize - 1; ++i)
                    {
                        var e1 = entries.GetArrayElementAtIndex(i);
                        var e2 = entries.GetArrayElementAtIndex(i + 1);

                        if (e1.FindPropertyRelative("delay").floatValue > e2.FindPropertyRelative("delay").floatValue)
                        {
                            entries.MoveArrayElement(i + 1, i);
                            changed = true;
                            break;
                        }
                    }
                }
            }


            // Set indent back to what it was
            EditorGUI.indentLevel = indent;
            //


            EditorGUI.EndProperty();
        }


        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            SerializedProperty entries = property.FindPropertyRelative("entries");
            float lineAndSpace = k_LineHeight + k_Spacing;
            return 40 + (entries.arraySize*lineAndSpace) + lineAndSpace;
        }
    }
#endif
}

