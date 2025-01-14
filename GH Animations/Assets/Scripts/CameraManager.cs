using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace UnityStandardAssets.Utility
{
public class CameraManager : MonoBehaviour
{
    public CameraList CameraListPos;
	public Transform Target;
		
		public enum Action
        {
            ChangeCamPos,
            Call,
        }


        [Serializable]
        public class Entry
        {
            //public string PerfAnim;
			public int CameraPos;
			public Action action;
            public float delay;
        }


        [Serializable]
        public class Entradas
        {
            public Entry[] entries;
        }
        
        
        public Entradas entries = new Entradas();

        
        private void Awake()
        {
            foreach (Entry entry in entries.entries)
            {
                switch (entry.action)
                {
                    case Action.ChangeCamPos:
                        StartCoroutine(ChangeCamPos(entry));
                        break;                    
                }
            }
        }


        private IEnumerator ChangeCamPos(Entry entry)
        {
            yield return new WaitForSeconds(entry.delay);
			//Band.SingerAnim.Play (entry.PerfAnim, 0, 0f);
			Target.parent = CameraListPos.CameraListPos[entry.CameraPos].transform;
			Target.localPosition = new Vector3 (0f,0f,0f);
			Target.rotation = CameraListPos.CameraListPos[entry.CameraPos].transform.rotation;
		}
    }
}

namespace UnityStandardAssets.Utility.Inspector
{
#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof (CameraManager.Entradas))]
    public class EntradasDrawer : PropertyDrawer
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
                float CameraPosWidth = .6f*width;
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

                    Rect CameraPosRect = new Rect(rowX, y, CameraPosWidth, k_LineHeight);
                    rowX += CameraPosWidth;

                    Rect delayRect = new Rect(rowX, y, delayWidth, k_LineHeight);
                    rowX += delayWidth;

                    Rect buttonRect = new Rect(rowX, y, buttonWidth, k_LineHeight);
                    rowX += buttonWidth;

                    // Draw fields - passs GUIContent.none to each so they are drawn without labels

                        EditorGUI.PropertyField(actionRect, entry.FindPropertyRelative("action"), GUIContent.none);
                        //EditorGUI.PropertyField(targetRect, entry.FindPropertyRelative("target"), GUIContent.none);
					EditorGUI.PropertyField(CameraPosRect, entry.FindPropertyRelative("CameraPos"), GUIContent.none);	
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
