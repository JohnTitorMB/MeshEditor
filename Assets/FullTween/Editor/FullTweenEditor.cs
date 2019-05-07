using UnityEditor;
using System;
using System.Reflection;
using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

[CustomEditor(typeof(FullTween))]
public class FullTweenEditor : Editor
{ 
    public override void OnInspectorGUI()
    {        
        Type[] tweenType = { typeof(Int16), typeof(Int16[]),
                         typeof(Int32), typeof(Int32[]),
                         typeof(Int64), typeof(Int64[]),
                         typeof(UInt16), typeof(UInt16[]),
                         typeof(UInt32), typeof(UInt32[]),
                         typeof(UInt64), typeof(UInt64[]),
                         typeof(float),typeof(float[]),
                         typeof(double),typeof(double[]),
                         typeof(Vector2),typeof(Vector2[]),
                         typeof(Vector2Int),typeof(Vector2Int[]),
                         typeof(Vector3), typeof(Vector3[]),
                         typeof(Vector3Int), typeof(Vector3Int[]),
                         typeof(Vector4), typeof(Vector4[]),
                         typeof(Matrix4x4), typeof(Matrix4x4[]),
                         typeof(Color), typeof(Color[]),
                         typeof(Color32), typeof(Color32[])};

        FullTween fullTween = (FullTween)target;

        SerializedProperty activeOnStartProperty = serializedObject.FindProperty("activeOnStart");
        EditorGUILayout.PropertyField(activeOnStartProperty);

        SerializedProperty functionProperty = serializedObject.FindProperty("function");
        
        EditorGUILayout.PropertyField(functionProperty);

        ArrayList componentObjectList = new ArrayList();
        Component[] components = fullTween.GetComponents<Component>();
        Dictionary<string, int> ComponentID = new Dictionary<string, int>();
        for (int i = 0; i < components.Length; i++)
        {
            if (components[i])
            {
                if (components[i].GetType() != typeof(FullTween))
                {
                    bool existComponent = true;

                    string name = components[i].GetType().Name;
                    int compenentNumb = 1;
                    while (existComponent)
                    {
                        if (ComponentID.ContainsKey(name))
                        {
                            name = components[i].GetType().Name + " " + compenentNumb;
                            compenentNumb++;
                        }
                        else
                            existComponent = false;

                    }
                
                         componentObjectList.Add(name);
                    
                    ComponentID.Add(name, i);
                }
            }
        }

        string[] componentObjectStringArray = (string[])componentObjectList.ToArray(typeof(string));

        int newComponentSelected;
        newComponentSelected = EditorGUILayout.Popup( "Component:", fullTween.ComponentSelected, componentObjectStringArray, EditorStyles.popup);

        if (newComponentSelected != fullTween.ComponentSelected)
            fullTween.ValueSelected = 0;

        fullTween.ComponentSelected = newComponentSelected;

        int componentID;
        if (fullTween.ComponentSelected < componentObjectStringArray.Length && fullTween.ComponentSelected > -1)
        {
            if (ComponentID.TryGetValue(componentObjectStringArray[fullTween.ComponentSelected], out componentID))
            {
                fullTween.ComponentTweenID = componentID;
                Type componentType = components[componentID].GetType();

                PropertyInfo[] propertiesInfo = componentType.GetProperties();
                ArrayList valueComponentList = new ArrayList();
                Dictionary<string, int> propertiesID = new Dictionary<string, int>();
                for (int i = 0; i < propertiesInfo.Length; i++)
                {
                    if (propertiesInfo[i] == null)
                        continue;

                    Type propertyType = propertiesInfo[i].PropertyType;

                    if (Array.IndexOf(tweenType, propertyType) != -1)
                    {
                        object obj = propertiesInfo[i].GetValue(components[componentID], null);
                        if (obj != null)
                        {
                            TextInfo UsaTextInfo = new CultureInfo("en-US", false).TextInfo;
                            string capitalized = UsaTextInfo.ToTitleCase(propertiesInfo[i].Name);

                            valueComponentList.Add(capitalized);
                            propertiesID.Add(capitalized, i);
                        }
                    }
                }

                string[] valueComponentStringArray = (string[])valueComponentList.ToArray(typeof(string));

                fullTween.ValueSelected = EditorGUILayout.Popup("Property:", fullTween.ValueSelected, valueComponentStringArray, EditorStyles.popup);
                int id;
                if (fullTween.ValueSelected < valueComponentStringArray.Length && fullTween.ValueSelected > -1)
                {
                    if (propertiesID.TryGetValue(valueComponentStringArray[fullTween.ValueSelected], out id))
                    {

                        Type T = propertiesInfo[id].PropertyType;
                        SerializedProperty endValueProperties = serializedObject.FindProperty("endValueField");
                        SerializedProperty endValueProperty = endValueProperties.FindPropertyRelative(T.Name + "EndValue");


                        fullTween.propertyInfoTweenID = id;

                        if (endValueProperty == null)
                        {
                            fullTween.isInitialise = false;

                            return;
                        }
                        EditorGUILayout.PropertyField(endValueProperty);

                        SerializedProperty activePhysicsProperty = serializedObject.FindProperty("activePhysic");
                        EditorGUILayout.PropertyField(activePhysicsProperty);

                        SerializedProperty targetModeProperty = serializedObject.FindProperty("targetMode");
                        EditorGUILayout.PropertyField(targetModeProperty);

                        SerializedProperty durationProperty = serializedObject.FindProperty("duration");
                        EditorGUILayout.PropertyField(durationProperty);

                        serializedObject.ApplyModifiedProperties();

                        fullTween.isInitialise = true;

                    }
                }
                else
                    fullTween.isInitialise = false;
            }
        }
        else
            fullTween.isInitialise = false;
    }
}
