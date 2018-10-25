﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

// TODO 1: Create a simple class to contain one entry in the blackboard
// should at least contain the gameobject, position, timestamp and a bool
// to know if it is in the past memory
public class Entry
{
    public GameObject gameObject;
    public Vector3 position;
    public float timestamp = 0;
    public bool pastMem = false;

    public Entry(GameObject GO)
    {
        gameObject = GO;
        position = GO.transform.position;
        timestamp = Time.time;
    }
}

public class AIMemory : MonoBehaviour {

	public GameObject Cube;
	public Text Output;

    // TODO 2: Declare and allocate a dictionary with a string as a key and
    // your previous class as value
    Dictionary<string, Entry> entries;

    // TODO 3: Capture perception events and add an entry if the player is detected
    // if the player stop from being seen, the entry should be "in the past memory"

    public void AddEntry(GameObject goAdd)
    {
        Entry entry;
        if (entries.TryGetValue(goAdd.name, out entry))
        {
            entry.pastMem = false;
        }
        else
        {
            entry = new Entry(goAdd);
            entries.Add(goAdd.name, entry);
        }
        Cube.transform.position = goAdd.transform.position;
    }

    public void PastMemChange(GameObject goChange)
    {
        Entry entry;
        if (entries.TryGetValue(goChange.name, out entry))
            entry.pastMem = true;
    }

    // Use this for initialization
    void Start () {
        entries = new Dictionary<string, Entry>();
	}
	
	// Update is called once per frame
	void Update () 
	{
        foreach(KeyValuePair<string, Entry> entry in entries)
        {
            if (entry.Value.pastMem == false)
            {
                entry.Value.position = entry.Value.gameObject.transform.position;
                entry.Value.timestamp += Time.deltaTime;
                Cube.transform.position = entry.Value.position;
            }
            // TODO 4: Add text output to the bottom-left panel with the information
            // of the elements in the Knowledge base
            string name = entry.Value.gameObject.name;
            string position = entry.Value.position.ToString("0.0");
            string time = entry.Value.timestamp.ToString("0.0");
            string inMem = entry.Value.pastMem.ToString();
            Output.text = name + position + time + inMem;
        }
	}

}


