using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
public class generalcontrol : MonoBehaviour {
	
	public List<GameObject> listaaves;
	public GameObject[,]matrixbase ;
	public GameObject point;
	public GameObject ave;
	public float  Vx = 0.33f, Vy = 0.33f, W, c1, c2;
	public int numeroaves, dimensaomatriz, maximoiteracoes ;
	float x , y;
	int startsimulation = 0;
	public InputField InputField1;
	public InputField InputField2;
	public InputField InputField3;
	public InputField InputField4;
	public Toggle t1;
	public Toggle t2;
	public Toggle t3;
	float medpbest;
	float sumpbest;



	Rigidbody rb;
	// Use this for initialization
	void Start () {
		


	}

	public float calculaaltura(float i, float j){

		i = i - 100;
		j = j - 100;
	
		//esfera
		float altura= 0;

		if (t1.isOn) {
			//esfera
		altura	= (Mathf.Pow (i, 2) + Mathf.Pow (j, 2)) / 100;

		} else if (t2.isOn) {

			//senoide
			altura =  5*(Mathf.Sin((i/5))) +5*(Mathf.Sin((j/5)))+ Mathf.Sqrt(Mathf.Pow((i/10), 2)) + Mathf.Sqrt(Mathf.Pow((j/10), 2));

		} else if (t3.isOn) {

		//linear
			altura = (Mathf.Sqrt(Mathf.Pow (i, 2)) + Mathf.Sqrt(Mathf.Pow (j, 2)))/5;

	}


	

		return altura;
		
	}
	// Update is called once per frame
	void Update () {
		
	
		
	}

	public void simular(){
		if (startsimulation < 1) {
			startsimulation = 1;
			numeroaves = int.Parse (InputField1.text);
			W = float.Parse (InputField2.text);
			c1 = float.Parse (InputField3.text);
			c2 = float.Parse (InputField4.text);


			matrixbase = new GameObject[dimensaomatriz, dimensaomatriz];
			for (int i = 0; i < dimensaomatriz; i++) {
				for (int j = 0; j < dimensaomatriz; j++) {

					float altura = calculaaltura (i, j);

					matrixbase [i, j] = ((GameObject)Instantiate (point, new Vector3 (i, altura, j), Quaternion.identity));

					matrixbase [i, j].SetActive (true);
				}
			}

			listaaves = new List<GameObject> ();

			for (int z = 0; z < numeroaves; z++) {
				x = Random.Range (-100, dimensaomatriz - 1);
				y = Random.Range (-100, dimensaomatriz - 1);

				listaaves.Add ((GameObject)Instantiate (ave, new Vector3 (x, 50, y), Quaternion.identity));
			}


			aveScript.simulacao = true;
		}
	}

	public void pausarsimulacao(){

		aveScript.simulacao= !(aveScript.simulacao);
	}

	public void restartsimulation(){
		SceneManager.LoadScene (0);

	}
}
