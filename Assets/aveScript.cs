using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class aveScript : MonoBehaviour {


	public float[] pbest = new float[2];
	int n =0;
	float[] pos = new float[2];
	float  Vx, Vy, W, c1, c2;
	public static float gbestfitness = 10000;
	public static float[] gbest = new float[2];
	public float fitness= 10000, pbestfitness;
	int nmax;
	public static bool simulacao;
	public static Text textfield;

	Rigidbody rb;
	// Use this for initialization
	void Start () {

	
		textfield = GameObject.Find ("gbestshow").GetComponent<Text> ();
		pos [0] = this.transform.position.x;
		pos [1] = this.transform.position.z;
		pbest[0] = pos[0];
		pbest[1] = pos[1];
		gbest[0] = pos[0];
		gbest[1] = pos[1];
		pbestfitness= GameObject.Find ("GeneralControl").GetComponent<generalcontrol> ().calculaaltura (pos [0], pos [1]);
		gbestfitness = fitness;
		nmax = GameObject.Find ("GeneralControl").GetComponent<generalcontrol> ().maximoiteracoes;


		rb = this.GetComponent<Rigidbody>();


		Vx = GameObject.Find ("GeneralControl").GetComponent<generalcontrol> ().Vx;
		Vy = GameObject.Find ("GeneralControl").GetComponent<generalcontrol> ().Vy;
		W = GameObject.Find ("GeneralControl").GetComponent<generalcontrol> ().W;
		c1 = GameObject.Find ("GeneralControl").GetComponent<generalcontrol> ().c1;
		c2 = GameObject.Find ("GeneralControl").GetComponent<generalcontrol> ().c2;
	

	}
	
	// Update is called once per frame
	void Update () {

		if (simulacao == true) {
		
			pos [0] = this.transform.position.x;
			pos [1] = this.transform.position.z;
	
			if (n < nmax) {
				fitness = GameObject.Find ("GeneralControl").GetComponent<generalcontrol> ().calculaaltura (pos [0], pos [1]);


				if (fitness < pbestfitness) {
					pbest [0] = pos [0];
					pbest [1] = pos [1];
					pbestfitness = fitness;
				}
				if (pbestfitness < gbestfitness) {
					gbest [0] = pbest [0];
					gbest [1] = pbest [1];
					gbestfitness = pbestfitness;


					textfield.text = "Gbest:  " + gbest [0].ToString () + " " + gbest [1].ToString () +" Fitness: " + gbestfitness;
				}

	
	
				interact ();
		
				this.transform.LookAt (new Vector3 (gbest [0], 10, gbest [1]));

				rb.velocity = (new Vector3 (Vx, 0, Vy));

			} else {

				Debug.Log ("terminou");
			}
		} else {
			rb.velocity = (new Vector3 (0, 0, 0));
		}
	}


	void interact(){

	
		Vx = (W * Vx + c1 * (pbest [0] - pos [0]) + c2  * (gbest [0] - pos [0]));
		Vy = (W * Vy + c1  * (pbest [1] - pos [1]) + c2 * (gbest [1] - pos [1]));

		//GameObject.Find ("GeneralControl").GetComponent<generalcontrol> ().printgbest(gbestfitness);

		//Debug.Log ("gbestfit" + gbestfitness + "  " + fitness);
			//Debug.Log(pbest[0] + " " + pbest[1] +  "   " + gbest[0] + "  " + gbest[1]);

		//Debug.Log ("vel" + Vx + " " + Vy);
		//Debug.Log ("pos " + pos [0] + " " + pos [1]);
		//Debug.Log ("VX = " + W + " " + Vx + " " + c1 + " " + phi1 + " " + pbest [0] + " " + pos [0] + " " + c2 + " " + phi2 + " " + gbest [0] + " " + pos [0]);
	//Debug.Log ("VY = " + W + " " + Vy + " " + c1 + " " + phi1 + " " + pbest [1] + " " + pos [1] + " " + c2 + " " + phi2 + " " + gbest [1] + " " + pos [1]);


	}



}
