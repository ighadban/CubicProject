﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour {

    //Public Variables
    Camera mainCamera;
    bool carrying;
    GameObject carriedObject;
    public float distance = 3;
    AudioManager audioManager;
    public AudioClip pickupSound;
    //Public Materials
    /*public Material goodCube;
    public Material goodAlpha;
    public Material badCube;
    public Material badAlpha;
    */

	// Use this for initialization
	void Start () {
        mainCamera = Camera.main;
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (carrying) {
            Carry(carriedObject);
            CheckDrop();
        } else {
            Pickup();
        }

        distance += Input.GetAxis("Mouse ScrollWheel") * 1.0f;

        distance = Mathf.Clamp(distance, 1.5f, 5.0f);
	}

    void Carry(GameObject o) {
        
        o.transform.position = Vector3.Lerp(o.transform.position, mainCamera.transform.position + mainCamera.transform.forward * distance, Time.deltaTime * 5);

        if (Input.GetKey(KeyCode.E)) {
            o.transform.Rotate(Vector3.up, Time.deltaTime * 60);
        } else if (Input.GetKey(KeyCode.Q)) {
            o.transform.Rotate(-Vector3.up, Time.deltaTime * 60);
        }

    }

    void Pickup() {
        if (Input.GetMouseButtonDown(0)) {
            int x = Screen.width / 2;
            int y = Screen.height / 2;

            Ray ray = mainCamera.ScreenPointToRay(new Vector3(x, y));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                Pickupable p = hit.collider.GetComponent<Pickupable>();
                if (p != null /*&& !p.GetComponent<Pickupable>().fixedBlock*/) {
                    carrying = true;
                    carriedObject = p.gameObject;
                    p.GetComponent<Rigidbody>().isKinematic = true;
                    p.GetComponent<Collider>().enabled = false;
                    p.GetComponent<MeshRenderer>().material = p.GetComponent<Pickupable>().alpha;
                    p.transform.rotation = Quaternion.identity;
                    p.GetComponent<Pickupable>().beenPickedUp = true;
                    audioManager.PlayAudio(pickupSound);
                }
            }
        }
    }

    void CheckDrop() {
        if (Input.GetMouseButtonDown(0)) {
            DropObject();
        }
    }

    void DropObject() {
        carrying = false;
        carriedObject.GetComponent<MeshRenderer>().material = carriedObject.GetComponent<Pickupable>().notAlpha;
        carriedObject.GetComponent<Rigidbody>().isKinematic = false;
        carriedObject.GetComponent<Collider>().enabled = true;
        carriedObject = null;
        distance = 3.0f;
    }
}
