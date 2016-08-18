using UnityEngine;
using System.IO;
using System;
using System.Text;
using System.Collections.Generic;

public class Init : MonoBehaviour {
	//Score Version
	string VERSION = "0.0";
	string TITLE;
	int BPM = 0;

	//Note
	Stack<byte[]> TABLEVALUE = new Stack<byte[]>();

	void Start() {
		StreamReader sr;
		if((sr = ReadFile("test.txt")) != null) {
			analysis(sr);
			Debug.Log("tets");
		}
		
	}

	/*
	protected Init() {
		StreamReader sr = ReadFile("test.txt");
		analysis(sr);
		Debug.Log("tets");
	}
	*/
	private StreamReader ReadFile(string name) { //OpenFile
		StreamReader sr = null;
		try {
			sr = new StreamReader(Application.dataPath + "/" + name,Encoding.UTF8);			 
		} catch (Exception e) {
			Debug.LogError(e);
		}
		return sr;
	}

	protected void analysis(StreamReader sr) {//Select Version
		VERSION = sr.ReadLine().Split(':')[1];
		switch(VERSION){
			case "1.0":
				ver1_0(sr);
				break;
			default:
				Debug.LogError("Designated version is nonexistent");
				break;
		}
	}
	private void ver1_0(StreamReader sr) {//Read Date
		string s;
		new Action(() => {
			while((s = sr.ReadLine()) != null) {
				switch(s.Split(':')[0]) {
					case "":
						return;
					case "TITLE":
						TITLE = s.Split(':')[1];
						break;
					case "BPM":
						BPM = int.Parse(s.Split(':')[1]);
						break;
					default:
						Debug.Log(s.Split(':')[0] + "is no　definition");
						break;
				}
			}
		})();				
		new Action(() => {
			byte[] date = new byte[4];
			while((s = sr.ReadLine()) != null) {
				//date = (byte)s.Split(',')[0]; 
				Debug.Log(s);
					/*
					switch(s){

					}
					*/
			}
		})();
	}
}
