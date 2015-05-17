using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RechangeBehaviour : MonoBehaviour {

	public InputField InputFieldName;
	public InputField InputFieldIDuser;
	public InputField InputFieldPhone;
	public Button ButtonRechange;
	public Button ButtonBack;
	public Button ButtonSelectBank;
	public Button ButtonBancolombia;
	public Button ButtonDavivienda;
	public Button ButtonBogota;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Awake()
	{
		ButtonBancolombia.onClick.AddListener (delegate {
			ButtonRechange.transform.FindChild("Text").GetComponent<Text>().text;
		});
	}
}
