using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	[SerializeField]
	private GameStateBehaviour gameState;
	[SerializeField]
	private GameObject main;
	[SerializeField]
	private GameObject history;
	[SerializeField]
	private GameObject recharge;
	[SerializeField]
	private GameObject pay;

	void Start () {
	}
	
	void Update(){
		if (Input.GetKeyDown (KeyCode.Escape)) 
			Application.Quit (); 

		if (gameState.GameState == GameState.Main) {
			main.SetActive(true);
			history.SetActive(false);
			recharge.SetActive(false);
			pay.SetActive(false);
		}
		if(gameState.GameState == GameState.History) {
			main.SetActive(false);
			history.SetActive(true);
			recharge.SetActive(false);
			pay.SetActive(false);
		}

		if(gameState.GameState == GameState.Recharge) {
			main.SetActive(false);
			history.SetActive(false);
			recharge.SetActive(true);
			pay.SetActive(false);
		}
		if(gameState.GameState == GameState.Pay) {
			main.SetActive(false);
			history.SetActive(false);
			recharge.SetActive(false);
			pay.SetActive(true);
		}
	}

	void Awake(){
		Input.multiTouchEnabled = false;
	}
}
