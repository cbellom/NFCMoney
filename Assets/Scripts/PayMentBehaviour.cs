using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PayMentBehaviour : MonoBehaviour {
	public InputField InputFieldReference;
	public Button  ButtonFielreference;
	public DatsPayMentBehaviour dastpaymentuser;
	public GameStateBehaviour gamestate;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void Awake()
	{
		ButtonFielreference.onClick.AddListener (delegate {
			gamestate.GameState= GameState.DastPayMent;
			StartCoroutine(dastpaymentuser.FindTransactionOnServer(InputFieldReference.text));
		});
	}



}
