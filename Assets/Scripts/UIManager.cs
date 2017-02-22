using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Text cubeTextUI;
    public Text uiText;
    public Text helpText;
    Player player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        helpText.gameObject.SetActive(false);
        uiText.gameObject.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
        cubeTextUI.text = player.cubeText;
        
        if (Input.GetKeyDown(KeyCode.Tab)) {
            helpText.gameObject.SetActive(true);
            uiText.gameObject.SetActive(false);

        } else if (Input.GetKeyUp(KeyCode.Tab))
        {
            helpText.gameObject.SetActive(false);
            uiText.gameObject.SetActive(true);
        }
    }
}
