using UnityEngine;
using UnityEngine.UI; // habilitando componentes UI da cena para serem chamados pelo script
using System.Collections;

public class temaJogo : MonoBehaviour {

	public Button 		btnPlay;
	public Button		btnReset;
	public Text 		txtNomeTema;

	public GameObject 	infoTema;
	public Text 		txtInfoTema;
	public GameObject	estrela1;
	public GameObject	estrela2;
	public GameObject	estrela3;


	public string[]		nomeTema;
	private int	 		numeroQuestoes;

	private int 		idTema;

	// Use this for initialization
	void Start () {

		idTema = 0;
		txtNomeTema.text = nomeTema[idTema];
		txtInfoTema.text = "";
		infoTema.SetActive (false);
		estrela1.SetActive (false);
		estrela2.SetActive (false);
		estrela3.SetActive (false);
		btnPlay.interactable = false;
		btnReset.interactable = false;
		//numeroQuestoes = responder.perguntas.Length;
	}
	

	public void selecioneTema(int i){
		idTema = i;
		PlayerPrefs.SetInt ("idTema", idTema);
		txtNomeTema.text = nomeTema[i];
		int notaFinal = PlayerPrefs.GetInt ("notaFinal"+idTema.ToString());
		int acertos = PlayerPrefs.GetInt("acertos"+idTema.ToString());
		numeroQuestoes = PlayerPrefs.GetInt("numeroQuestoes"+idTema.ToString());

		estrela1.SetActive (false);
		estrela2.SetActive (false);
		estrela3.SetActive (false);

		txtInfoTema.text = "Você acertou " + acertos.ToString() + " de " + numeroQuestoes.ToString() + " perguntas";
 		
		if (notaFinal == 10) {
			estrela1.SetActive (true);
			estrela2.SetActive (true);
			estrela3.SetActive (true);
		} else if (notaFinal >= 7) {
			estrela1.SetActive (true);
			estrela2.SetActive (true);
			estrela3.SetActive (false);
		} else if (notaFinal >= 5) {
			estrela1.SetActive (true);
			estrela2.SetActive (false);
			estrela3.SetActive (false);
		}

		infoTema.SetActive (true);
		btnPlay.interactable = true;
		btnReset.interactable = false;
		if (notaFinal >= 5) {
			btnReset.interactable = true;
		}

	}

	public void jogar(){
		Application.LoadLevel ("T"+idTema.ToString());
	}

	public void resetarPontuacao(){
		PlayerPrefs.DeleteKey("notaFinal"+idTema.ToString());
		PlayerPrefs.DeleteKey("acertos"+idTema.ToString());
		Application.LoadLevel ("temas");
	}


}
