using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script que maneja un brazo del muñeco
 */
public class Limb : MonoBehaviour {

	public Transform brazo; // brazo
	public Transform shoulder; // hombro
	public Quaternion dondeInicio; // donde se ubica el brazo para rotar

	// Aqui damos parámetros de balanceo
	public float speed = 5.0f; // A qué velocidad
	public float factor = 9; // Factor de ajustar giro. Si no agregamos el brazo se balancea mucho
	public bool isSwinging = true; // Puede balancearse
	public float direccion = 1; // Desde donde balanceo delante o detras

	// Use this for initialization
	void Start () {

		brazo = GetComponent<Transform> ().GetChild(0);
		shoulder = GetComponent<Transform> ().GetChild(1);
		dondeInicio = GetComponent<Transform> ().rotation;
	}

	// Update is called once per frame
	void Update () {

		if ( isSwinging ) {

			doSwinging ();
		}
	}

	// Hace brazo balanceándose
	void doSwinging () {

		Quaternion dondeHace = dondeInicio;

		var distancia = Time.time * speed;
		dondeHace.z += (Mathf.Sin(distancia) / factor) * direccion; // Aplicamos Seno
		print ("Mis calculos son dondeHace = " + dondeHace.z + ", sin(a) = " + Mathf.Sin(distancia) + ", deltaTime = " + Time.deltaTime + ", time = " + Time.time);
		GetComponent<Transform> ().rotation = dondeHace;
	}
}
