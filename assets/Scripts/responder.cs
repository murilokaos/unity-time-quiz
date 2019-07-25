using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class responder : MonoBehaviour {

	private int 	idTema;
	private int 	notaFinal;

	public Text 	txtPergunta;
	public Text 	txtRespostaA;
	public Text 	txtRespostaB;
	public Text 	txtRespostaC;
	public Text 	txtRespostaD;
	public Text 	txtInfoRespostas;

	private int 		idModo;
	public GameObject 	barraDeProgresso;
	public float 		tempoFinal;

	public string[] perguntas; // Armazena todas as perguntas
	public string[] alternativasA; // Armazena todas as alternativas A
	public string[] alternativasB; // Armazena todas as alternativas B
	public string[] alternativasC; // Armazena todas as alternativas C
	public string[] alternativasD; // Armazena todas as alternativas D

	public string[] corretas; // Armazena todas as alternativas corretas

	private int 	idPergunta;

	private float 	acertos;
	private float	media;
	private float	questoes;

	// Use this for initialization
	void Start () {
		idTema = PlayerPrefs.GetInt ("idTema");
		idModo = PlayerPrefs.GetInt ("idModo");
		idPergunta = 0;
		PlayerPrefs.SetInt ("idPergunta", idPergunta);
		questoes = perguntas.Length;
		txtPergunta.text = perguntas [idPergunta];
		txtRespostaA.text = alternativasA [idPergunta];
		txtRespostaB.text = alternativasB [idPergunta];
		txtRespostaC.text = alternativasC [idPergunta];
		txtRespostaD.text = alternativasD [idPergunta];
		txtInfoRespostas.text = "Respondendo " + (idPergunta + 1).ToString() + " de " + questoes.ToString() + " perguntas";

		if (idModo == 1) {

		} else if (idModo == 3) {
			tempoFinal = 3.0f;
		} else if (idModo == 10) {
			tempoFinal = 10.0f;
		}

	}

	void Update () {
		if (idModo == 1) {
			barraDeProgresso.transform.localScale = new Vector3 (0, barraDeProgresso.transform.localScale.y, barraDeProgresso.transform.localScale.z);
		} else if (idModo == 3) {
			barraDeProgresso.transform.localScale = new Vector3 (tempoFinal / 3, barraDeProgresso.transform.localScale.y, barraDeProgresso.transform.localScale.z);
			
			tempoFinal -= Time.deltaTime;
			
			if (tempoFinal == 0 || tempoFinal < 0) {
				proximaPergunta ();
				tempoFinal = 3.0f;
			}
		} else if (idModo == 10) {
			barraDeProgresso.transform.localScale = new Vector3 (tempoFinal / 10, barraDeProgresso.transform.localScale.y, barraDeProgresso.transform.localScale.z);
			
			tempoFinal -= Time.deltaTime;
			
			if (tempoFinal == 0 || tempoFinal < 0) {
				proximaPergunta ();
				tempoFinal = 10.0f;
			}
		}
	}

	public void resposta(string alternativa){
		if (alternativa == "A") {
			if(alternativasA[idPergunta] == corretas[idPergunta]){
				acertos += 1;
			}
		}else if(alternativa == "B"){
			if(alternativasB[idPergunta] == corretas[idPergunta]){
				acertos += 1;
			}
		}else if(alternativa == "C"){
			if(alternativasC[idPergunta] == corretas[idPergunta]){
				acertos += 1;
			}
		}else if(alternativa == "D"){
			if(alternativasD[idPergunta] == corretas[idPergunta]){
				acertos += 1;
			}
		}
		proximaPergunta ();
	}

	public void proximaPergunta(){
		if (idPergunta < (questoes - 1)) {
			idPergunta += 1;
			PlayerPrefs.SetInt ("idPergunta", idPergunta);
			txtPergunta.text = perguntas [idPergunta];
			txtRespostaA.text = alternativasA [idPergunta];
			txtRespostaB.text = alternativasB [idPergunta];
			txtRespostaC.text = alternativasC [idPergunta];
			txtRespostaD.text = alternativasD [idPergunta];
			txtInfoRespostas.text = "Respondendo " + (idPergunta + 1).ToString () + " de " + questoes.ToString () + " perguntas";

			if (idModo == 1) {
				
			} else if (idModo == 3) {
				tempoFinal = 3.0f;
			} else if (idModo == 10) {
				tempoFinal = 10.0f;
			}

		} else {

			media = 10 * (acertos / questoes); // calcula a media com base no percentual de acertos
			notaFinal = Mathf.RoundToInt(media); // Arredonda a media segundo a matematica

			if(notaFinal > PlayerPrefs.GetInt("notaFinal"+idTema.ToString())){
				PlayerPrefs.SetInt("notaFinal"+idTema.ToString(), notaFinal);
				PlayerPrefs.SetInt("acertos"+idTema.ToString(), (int) acertos);
			}

			PlayerPrefs.SetInt("numeroQuestoes"+idTema.ToString(), (int) questoes);
			PlayerPrefs.SetInt("notaFinalTemp"+idTema.ToString(), notaFinal);
			PlayerPrefs.SetInt("acertosTemp"+idTema.ToString(), (int) acertos);

			Application.LoadLevel("notaFinal");
		}
	}
}
