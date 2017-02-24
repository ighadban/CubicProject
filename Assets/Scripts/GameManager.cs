using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Net;

public class GameManager : MonoBehaviour {

    public GameObject[] cubes0;
    public GameObject[] cubes1;
    public GameObject[] cubes2;
    public GameObject[] cubes3;
    public GameObject[] cubes4;
    //public float maxCubes = 60;

    // Use this for initialization
    void Start () {

        //WebClient webClient = new WebClient();
        //webClient.DownloadFile("https://drive.google.com/uc?export=download&id=0B2tthDH6GnuULTNqamF1SkpNRHM", "testing.csv");


        LoadCubes();

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.Escape)) {
            SaveCubes();
            Application.Quit();
        }

        cubes0 = GameObject.FindGameObjectsWithTag("Cube0");
        cubes1 = GameObject.FindGameObjectsWithTag("Cube1");
        cubes2 = GameObject.FindGameObjectsWithTag("Cube2");
        cubes3 = GameObject.FindGameObjectsWithTag("Cube3");
        cubes4 = GameObject.FindGameObjectsWithTag("Cube4");


    }

    void SaveCubes() {
        StreamWriter sw = new StreamWriter("cubelocation.csv");          //  "d:\\test.csv" Application.persistentDataPath + "/cubelocation.csv"
        foreach (GameObject cubes in cubes0) {
            sw.Write("Cube0");
            sw.Write(",");
            sw.Write(cubes.transform.position.x);
            sw.Write(",");
            sw.Write(cubes.transform.position.y);
            sw.Write(",");
            sw.Write(cubes.transform.position.z);
            sw.Write(",");
            sw.Write(cubes.transform.eulerAngles.y);
            sw.Write("\n");
        }
        foreach (GameObject cubes in cubes1) {
            sw.Write("Cube1");
            sw.Write(",");
            sw.Write(cubes.transform.position.x);
            sw.Write(",");
            sw.Write(cubes.transform.position.y);
            sw.Write(",");
            sw.Write(cubes.transform.position.z);
            sw.Write(",");
            sw.Write(cubes.transform.eulerAngles.y);
            sw.Write("\n");
        }
        foreach (GameObject cubes in cubes2) {
            sw.Write("Cube2");
            sw.Write(",");
            sw.Write(cubes.transform.position.x);
            sw.Write(",");
            sw.Write(cubes.transform.position.y);
            sw.Write(",");
            sw.Write(cubes.transform.position.z);
            sw.Write(",");
            sw.Write(cubes.transform.eulerAngles.y);
            sw.Write("\n");
        }
        foreach (GameObject cubes in cubes3) {
            sw.Write("Cube3");
            sw.Write(",");
            sw.Write(cubes.transform.position.x);
            sw.Write(",");
            sw.Write(cubes.transform.position.y);
            sw.Write(",");
            sw.Write(cubes.transform.position.z);
            sw.Write(",");
            sw.Write(cubes.transform.eulerAngles.y);
            sw.Write("\n");
        }
        foreach (GameObject cubes in cubes4) {
            sw.Write("Cube4");
            sw.Write(",");
            sw.Write(cubes.transform.position.x);
            sw.Write(",");
            sw.Write(cubes.transform.position.y);
            sw.Write(",");
            sw.Write(cubes.transform.position.z);
            sw.Write(",");
            sw.Write(cubes.transform.eulerAngles.y);
            sw.Write("\n");
        }
        sw.Close();
        //sw.Flush();

    }
    void LoadCubes() {
        StreamReader sr = new StreamReader("cubelocation.csv");    //"d:\\test.csv" Application.persistentDataPath + "/cubelocation.csv" 
        Vector3 pos = new Vector3();
        float angle = 0.0f;
        string type;
                
        while (!sr.EndOfStream) {
            string s = sr.ReadLine();
            string[] sa = s.Split(',');
            type = (sa[0]);
            pos.x = float.Parse(sa[1]);
            pos.y = float.Parse(sa[2]);
            pos.z = float.Parse(sa[3]);
            angle = float.Parse(sa[4]);

            if (type == "Cube0") {
                Instantiate(GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().cube0, pos, Quaternion.Euler(0.0f, angle, 0.0f));
            }
            if (type == "Cube1") {
                Instantiate(GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().cube1, pos, Quaternion.Euler(0.0f, angle, 0.0f));
            }
            if (type == "Cube2") {
                Instantiate(GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().cube2, pos, Quaternion.Euler(0.0f, angle, 0.0f));
            }
            if (type == "Cube3") {
                Instantiate(GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().cube3, pos, Quaternion.Euler(0.0f, angle, 0.0f));
            }
            if (type == "Cube4") {
                Instantiate(GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().cube4, pos, Quaternion.Euler(0.0f, angle, 0.0f));
            }

        }
        sr.Close();
        //sw.Flush();

    }
}
