﻿using UnityEngine;
using System.Collections;

public class moveOffset : MonoBehaviour {

	private Material materialAtual;
	public float velocidade; // velocidade da transiçao
	private float offset; // Posiçao de movimento do background

	// Use this for initialization
	void Start () {
		materialAtual = GetComponent<Renderer> ().material;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		offset += 0.001f;
		materialAtual.SetTextureOffset ("_MainTex", new Vector2(offset * velocidade, 0));
	}
}
