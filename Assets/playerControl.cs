using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Text;

public class playerControl : MonoBehaviour {

    float speed = 7.0f;
    float inputX;
    float inputY;
	float move = 0; //move number
	int metSum = 0; // the total number of mets that popo hits 
	int fuelSum = 0; // the total number of fuels that popo hits
	public int planetSum = 0;
	public int endFlag = 0;
	// Use this for initialization
	int health = 100;
	// Use this for initialization
	public Text healthTxt;
	public Text messageTxt;
	public string[] msgStr;
	private int time = 10;
    private int ratetime = 10;

	void Awake()
	{
		// Get All of the sentence in text
		msgStr = System.IO.File.ReadAllLines(Application.streamingAssetsPath + "/msgTxt.txt");
		InvokeRepeating("ShowMessage", time, ratetime);
	}
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        
		healthTxt.text = health.ToString();
		// If the fuel lower than zero, popo would not be able to move anymore and the game will end
		if (health <= 0) 
		{
			// show the game ending

            // record the data in txt
			health = 0;
            ExitGame();
		}
		if (endFlag == 1)
		{
			ExitGame();
		}
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			ExitGame();
		}
		if(Input.GetKey(KeyCode.W))
		{
			print("w");
			transform.Translate(Vector3.up * Time.deltaTime * 1 * speed);
			move += Time.deltaTime * speed;
		}

		//向下运动——S
		if(Input.GetKey(KeyCode.S))
		{
			print("s");
			transform.Translate(Vector3.down * Time.deltaTime * 1 * speed);
			move += Time.deltaTime * speed;
		}

		//向左运动——A
		if(Input.GetKey(KeyCode.A))
		{
			print("a");
			transform.Translate(Vector3.left * Time.deltaTime * 1 * speed);
			move += Time.deltaTime * speed;
		}

		//向右运动——D
		if(Input.GetKey(KeyCode.D))
		{
			print("d");
			transform.Translate(Vector3.right * Time.deltaTime * 1 * speed);
			move += Time.deltaTime * speed;
		} 
    }
	
    void ShowMessage()
	{
		// choose one sentence from the pool
        messageTxt.text = msgStr[Random.Range(0,msgStr.Length)];
	}
	public void save(string information)
	{
		StreamWriter sw = new StreamWriter (Application.streamingAssetsPath + "/dataRec.txt");
		sw.Write (information);
		sw.Close();
		sw.Dispose();
	}
	public void ExitGame()
	{
		string info = move.ToString() + " " + health.ToString() + " " + metSum.ToString() + " " + planetSum.ToString() + " " + fuelSum.ToString();
		save(info);
        // exit
		#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}
	void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "met")
        {
            Destroy(other.gameObject);
			metSum++;
			health -= Random.Range(5,10);
			Debug.Log("met:" + metSum + " " + "health:" + health);
        }
		if(other.gameObject.tag == "fuel")
        {
            Destroy(other.gameObject);
			fuelSum++;
			health += 5;
			Debug.Log("fuel:" + fuelSum + " " + "health:" + health);
			//health += Random.Range(1,10);
        }
    }
	IEnumerator KillPlayer()
	{
		// After waiting reset the game
		yield return 0;//new WaitForSeconds(1.0f);
        int index = SceneManager.GetActiveScene().buildIndex;
		UnityEngine.SceneManagement.SceneManager.LoadScene(index);
	}
}
