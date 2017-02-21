using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    //Variables
    public float moveSpeed;

    //cube variables
    public GameObject cube0;
    public GameObject cube1;
    public GameObject cube2;
    public GameObject cube3;

    public GameObject selectedCube;

    public string cubeText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Movement();
        spawnCubes();
		
	}

    //Movement Controls
    void Movement() {


        //forward/reverse movement
        if (Input.GetKey(KeyCode.W)) {

            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S)) {

            transform.position += -transform.forward * moveSpeed * Time.deltaTime;
        }

        //left/right movement
        if (Input.GetKey(KeyCode.A)) {

            transform.position += -transform.right * moveSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D)) {

            transform.position += transform.right * moveSpeed * Time.deltaTime;
        }

        //up/down movement
        if (Input.GetKey(KeyCode.Space)) {

            transform.position += Vector3.up * moveSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.LeftShift)) {

            transform.position += -Vector3.up * moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            moveSpeed = 3.0f;
        }
        else {
            moveSpeed = 6.0f;
        }

    }

    void spawnCubes() {

        if (Input.GetKeyDown(KeyCode.Q)) {
            Instantiate(selectedCube, transform.position + (transform.forward * 2), transform.rotation);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedCube = cube0;
            cubeText = "Cube";
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedCube = cube1;
            cubeText = "Rectangular Prism";
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectedCube = cube2;
            cubeText = "Cylinder";
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            selectedCube = cube3;
            cubeText = "Upright Rectangular Prism";
        }
    }
}
