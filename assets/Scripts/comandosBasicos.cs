using UnityEngine;
using System.Collections;

public class comandosBasicos : MonoBehaviour {

	void Start (){
		Camera.main.aspect = 346f / 591f;
	}

	public void carregaCena (string nomeCena){
		Application.LoadLevel (nomeCena);
	}

	public void resetarPontuacoes(){
		PlayerPrefs.DeleteAll ();
		Application.LoadLevel ("modos");
	}
	
}
