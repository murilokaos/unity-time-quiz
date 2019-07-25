using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class modoJogo : MonoBehaviour {
	
	private float 			tempoFinal;
	public 	int 			idModo;
	public 	Text			txtModoJogo;
	public 	Button 			btnPlay;

	// Use this for initialization
	void Start () {
		txtModoJogo.text = "Selecione o modo de jogo";
		idModo = PlayerPrefs.GetInt ("idModo");
		if (idModo == 1) {
			txtModoJogo.text = "Responda com tempo infinito";
		} else if (idModo == 3) {
			txtModoJogo.text = "Responda em até 3s";
		} else if (idModo == 10) {
			txtModoJogo.text = "Responda em até 10s";
		}
	}
	
	public void selecioneModo(int i){
		idModo = i;
		PlayerPrefs.SetInt("idModo", idModo);
		btnPlay.interactable = true;

		if (idModo == 1) {
			txtModoJogo.text = "Responda com tempo infinito";
		} else if (idModo == 3) {
			txtModoJogo.text = "Responda em até 3s";
			} else if (idModo == 10) {
				txtModoJogo.text = "Responda em até 10s";
		}
	}

	public void modoSelecionado(int id){
		id = idModo;
		PlayerPrefs.SetInt("idModo", idModo);
	}
}
