using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour {

	public Transform fag; // pitillo
	public Quaternion dondeInicio; // donde se ubica el brazo para rotar
	public Vector3 fagUp;
	public Vector3 fagDown;

	// Aqui damos parámetros de balanceo
	public float speed = 1.0f; // A qué velocidad
	public float factor = 9; // Factor de ajustar giro. Si no agregamos el brazo se balancea mucho
	public bool isSwinging = true; // Puede balancearse
	public float startTime = 0;
	public float duration = 5;

	// Use this for initialization
	void Start () {

		fag = GetComponent<Transform> ();
		dondeInicio = fag.rotation;

		fagUp = fag.position;
		fagUp.x += 20;
		fagDown = fag.position;
		fagDown.x -= 20;
		startTime = Time.time;
	}

	// Update is called once per frame
	void Update () {

//		if ( isSwinging ) {
//
//			doSwinging ();
//		}
		doPunk();
	}

	// Hace cabeza balanceándose
	void doPunk () {

		// pendulo
		Quaternion dondeHace = dondeInicio;
		var distancia = Time.time * speed;
		dondeHace.z += ( (Mathf.Sin(distancia) / factor) + 0 ); // Aplicamos Seno
		fag.rotation = dondeHace;

		// pendulo por interpolacion
		Vector3.Slerp (fagUp, fagDown, (Time.time - startTime) / duration);

		// pendulo por clamp
//		fag.position = new Vector3(fag.position.x, Mathf.Clamp(98, fagUp.y, fagDown.y), 0);
	}
}
