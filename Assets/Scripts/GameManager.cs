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
	[SerializeField]
	private GameObject PayMent;


	void Start () {
	}
	
	void Update(){

		if (Input.GetKeyDown (KeyCode.Escape)) 
			Application.Quit (); 

		if (gameState.GameState == GameState.Main) {
			history.SetActive(false);
			recharge.SetActive(false);
			pay.SetActive(false);
			PayMent.SetActive(false);
			main.SetActive(true);

		}
		if(gameState.GameState == GameState.History) {

			main.SetActive(false);
			recharge.SetActive(false);
			pay.SetActive(false);
			PayMent.SetActive(false);
			history.SetActive(true);
		}

		if(gameState.GameState == GameState.Recharge) {

			main.SetActive(false);
			history.SetActive(false);
			pay.SetActive(false);
			PayMent.SetActive(false);
			recharge.SetActive(true);
		}
		if(gameState.GameState == GameState.Pay) {

			main.SetActive(false);
			history.SetActive(false);
			recharge.SetActive(false);
			PayMent.SetActive(false);
			pay.SetActive(true);
		}
		if(gameState.GameState == GameState.PayMent) {
		
			main.SetActive(false);
			history.SetActive(false);
			recharge.SetActive(false);
			PayMent.SetActive(true);
		}
	}

	void Awake(){
		Input.multiTouchEnabled = false;
	}
}
