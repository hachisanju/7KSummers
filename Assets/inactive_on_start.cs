﻿using UnityEngine;
using System.Collections;

public class inactive_on_start : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<CanvasRenderer> ().SetAlpha(0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
