using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Main : MonoBehaviour {
	public Transform Score;
	public Transform[] Bar;
	public Transform Note;
	string TITLE = "Test";
	int BPM = 0;
	int AllNOTE = 8;
	//Queue<int[]> TABLEVALUE = new Queue<int[]>();

	List<List<int>> TABLEVALUE2 = new List<List<int>>();

	Transform[,] TableNote = new Transform[500,4];

	
	int[] Next = {0,0,0,0};
	
	Transform[] NextGameObject = new Transform[4];
	int[] XTable = {-6,-2,2,6};
	int Space = 2;
	int Firstpos = 10;
	void Awake() {
		Debug.Log("Awake");
		Application.targetFrameRate = 60;
		/*
		TABLEVALUE.Enqueue(new int[]{1,0,0,0});
		TABLEVALUE.Enqueue(new int[]{0,1,0,0});
		TABLEVALUE.Enqueue(new int[]{0,0,1,0});
		TABLEVALUE.Enqueue(new int[]{0,0,0,1});
		TABLEVALUE.Enqueue(new int[]{1,0,0,0});
		TABLEVALUE.Enqueue(new int[]{0,1,0,0});
		TABLEVALUE.Enqueue(new int[]{0,0,1,0});
		TABLEVALUE.Enqueue(new int[]{0,0,0,1});
		*/
		TABLEVALUE2.Add(new List<int>{1,0,0,0});
		TABLEVALUE2.Add(new List<int>{0,1,0,0});
		TABLEVALUE2.Add(new List<int>{0,0,1,0});
		TABLEVALUE2.Add(new List<int>{0,0,0,1});
		TABLEVALUE2.Add(new List<int>{1,0,0,0});
		TABLEVALUE2.Add(new List<int>{0,1,0,0});
		TABLEVALUE2.Add(new List<int>{0,0,1,0});
		TABLEVALUE2.Add(new List<int>{0,0,0,1});
	}

	void OnEnable() {
		Debug.Log("OnEnable");
	}
	void Start() {
		Time.timeScale = 0;
		for(int i = 0;i < TABLEVALUE2.Count;i++) {
			for(int t = 0;t < 4;t++){
				if(TABLEVALUE2[i][t] == 1) {
					TableNote[Next[t],t] = (Instantiate(Note,new Vector2(XTable[t],i * Space + Firstpos),Quaternion.identity) as GameObject).transform;
					TableNote[Next[t],t].parent = Bar[t];
					Next[t]++;
				}
			}
		}
		/*
		for(int i = 0;TABLEVALUE.Count > 0;i++) {
			//Debug.Log(TableNote[0,0]);
			value = TABLEVALUE.Dequeue();
			for(int t = 0;t < 4;t++) {
				if(value[t] == 1) {
					TableNote[Next[t],t] = (Instantiate(Note,new Vector2(XTable[t],i * Space + Firstpos),Quaternion.identity) as GameObject).transform;
					TableNote[Next[t],t].parent = Bar[t];
					Next[t]++;
				}				
			}
		}
		*/
		Next[0] = 0;
		Next[1] = 0;
		Next[2] = 0;
		Next[3] = 0;
		NextGameObject[0] = TableNote[0,0].transform;
		NextGameObject[1] = TableNote[0,1].transform;
		NextGameObject[2] = TableNote[0,2].transform;
		NextGameObject[3] = TableNote[0,3].transform;

		Debug.Log("Start");		
		Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update() {
		Score.position -= new Vector3(0,Time.deltaTime * 5);
		for(int i = 0;i < 4;i++) {
			if(NextGameObject[i] != null && NextGameObject[i].position.y < -3) {
				Move(i);
			}
		}
		/*
		if(Input.GetKey(KeyCode.S)){
			Debug.Log("S");
		}
		if(Input.GetKey(KeyCode.D)){
			Debug.Log("D");
		}
		if(Input.GetKey(KeyCode.F)){
			Debug.Log("F");
		}
		if(Input.GetKey(KeyCode.G)){
			Debug.Log("G");
		}
		*/

		if(Input.GetKeyDown(KeyCode.S)){
			Judgment(0);
		}
		if(Input.GetKeyDown(KeyCode.D)){
			Judgment(1);
		}
		if(Input.GetKeyDown(KeyCode.F)){
			Judgment(2);
		}
		if(Input.GetKeyDown(KeyCode.G)){
			Judgment(3);
		}
	}

	void Judgment(int pos) {
		if(NextGameObject[pos] != null) {
			float Y = NextGameObject[pos].position.y;
			if(-1 < Y && Y < 1) {
				Debug.Log(pos + "pos" + Y  + "Good");
				Move(pos);
			} else if(-3 < Y && Y < 3) {
				Debug.Log(pos + "pos" + Y + "Bad");
				Move(pos);
			}
		}
	}

	void Move(int pos) {
		Next[pos]++;
		NextGameObject[pos] = TableNote[Next[pos],pos];
	}

	void Setting() {

	}
}
