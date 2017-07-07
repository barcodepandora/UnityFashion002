using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script que maneja los dos muñecos
 */
public class People : MonoBehaviour {

	public int dollPride = 1;
	public int dollAnger = 4;

	// Use this for initialization
	void Start () {

		doPride(); // haga emocion orgullo
		print(GetComponentsInChildren<MonoBehaviour>(true).Length);
		for (int i = 0; i < GetComponentsInChildren<MonoBehaviour>(true).Length; i++) {

			print ("Mi componente es " + GetComponentsInChildren<MonoBehaviour>(true)[i]);
		}
	}
	
	// Update is called once per frame
	void Update () {

		// reconocemos flecha izquierda
		if (Input.GetKey(KeyCode.LeftArrow)) {

			doPride(); // haga emocion orgullo
		} else if (Input.GetKey(KeyCode.RightArrow)) {
			
			doAnger(); // haga emocion ira
		}
	}

	// Hace emocion orgullo
	void doPride() {

		GetComponentsInChildren<MonoBehaviour>(true)[dollPride].gameObject.SetActive(true);
		GetComponentsInChildren<MonoBehaviour>(true)[dollAnger].gameObject.SetActive(false);
	}

	// Hace emocion ira
	void doAnger() {

		GetComponentsInChildren<MonoBehaviour>(true)[dollPride].gameObject.SetActive(false);
		GetComponentsInChildren<MonoBehaviour>(true)[dollAnger].gameObject.SetActive(true);
	}
}
