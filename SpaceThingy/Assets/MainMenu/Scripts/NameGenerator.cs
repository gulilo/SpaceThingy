using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;
using System;
using Random = UnityEngine.Random;

public class NameGenerator : MonoBehaviour
{
	public static NameGenerator Instance { get; private set; }

	public string malePath,femalePath,lastPath;
	private List<string> maleNames,femaleNames,lastNames;


	// Use this for initialization
	void Start()
	{
		if (Instance == null)
		{
			Instance = this;
		}

		maleNames = new List<string>();
		femaleNames = new List<string>();
		lastNames = new List<string>();

		readFile(malePath, maleNames);
		readFile(femalePath, femaleNames);
		readFile(lastPath, lastNames);
	}

	private void readFile(string path, List<string> arr)
	{
		try
		{
			string line;
			StreamReader theReader = new StreamReader(path, Encoding.Default);
			using (theReader)
			{
				do
				{
					line = theReader.ReadLine();
					if (line != null)
					{
						arr.Add(line);
					}
				}
				while (line != null);
				theReader.Close();
			}
		}
		catch (Exception e)
		{
			Debug.Log(e.Message);
		}
	}

	public string[] randomName(int gander)
	{
		string[] name = new string[2];
		int r;
		switch(gander)
		{
			case 0:
				r = Random.Range(0, maleNames.Count);
				name[0] = maleNames[r];
				break;
			case 1:
				r = Random.Range(0, femaleNames.Count);
				name[0] = femaleNames[r];
				break;

			default:
				name[0] = "noName";
				break;
		}
		r = Random.Range(0, lastNames.Count);
		name[1] = lastNames[r];
		return name;
	}
}
