using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class MainBehaviour : MonoBehaviour {

	public UserDataBehaviour userDataBehaviour;
	public Text MoneyPanel;
	// Use this for initialization
	public void Start () {
		puttotaluser ();
	}

	// Update is called once per frame
	public void Update () {
		puttotaluser ();
	}

	public void puttotaluser()
	{

		userDataBehaviour.Load ();
		UserData userdata = UserPersistence.userData;
		MoneyPanel.text=System.Convert.ToString(userdata.amount);
	}

}
