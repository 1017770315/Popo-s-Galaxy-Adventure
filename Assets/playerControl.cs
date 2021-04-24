using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour {

    float speed = 7.0f;
    float inputX;
    float inputY;
	float move = 0; //move number
	int metSum = 0; // the total number of mets that popo hits 
	int fuelSum = 0; // the total number of fuels that popo hits
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKey(KeyCode.W))
		{
			//print("w");
			transform.Translate(Vector3.up * Time.deltaTime * 1 * speed);
			move += Time.deltaTime * speed;
			//print(move);
		}

		//向下运动——S
		if(Input.GetKey(KeyCode.S))
		{
			//print("s");
			transform.Translate(Vector3.down * Time.deltaTime * 1 * speed);
			move += Time.deltaTime * speed;
			//print(move);

		}

		//向左运动——A
		if(Input.GetKey(KeyCode.A))
		{
			//print("a");
			transform.Translate(Vector3.left * Time.deltaTime * 1 * speed);
			move += Time.deltaTime * speed;
			//print(move);
		}

		//向右运动——D
		if(Input.GetKey(KeyCode.D))
		{
			//print("d");
			transform.Translate(Vector3.right * Time.deltaTime * 1 *speed);
			move += Time.deltaTime * speed;
			//print(move);
		}
        
    }
	void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "met")
        {
            Destroy(other.gameObject);
			metSum++;
        }
		if(other.gameObject.tag == "fuel")
        {
            Destroy(other.gameObject);
			fuelSum++;
        }
    }
}
