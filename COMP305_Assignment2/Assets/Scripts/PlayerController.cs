using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	//PRIVATE INSTANCE VARIABLES\
	private Transform _transform;
	private Rigidbody2D _rigidbody;
	private float _move;

	// Public Instance Variables
	public float Velocity = 10f;

	//public Camera camera;

	// Use this for initialization
	void Start () {
		this._initialize ();
	}
	
	// Update is called once per frame (Physics)
	void FixedUpdate () {
	// check if input is present for movement

		this._move = Input.GetAxis ("Horizontal");
		if (this._move > 0f) {
			this._move = 1;
		} else if (this._move < 0f) {
			this._move = -1;
		}
		else {
			this._move = 0f;
	}

		this._rigidbody.AddForce (new Vector2 (this._move * this.Velocity, 0f), ForceMode2D.Force);
		//this.camera.transform.position = new Vector3 (this._transform.position.c, this._transfrom.position.y, -10f)
	}
	//Private Methods
	//initialize variables when object called
	public void _initialize() {
		this._transform = GetComponent<Transform> ();
		this._rigidbody = GetComponent<Rigidbody2D> ();
		this._move = 0f;
	}
}
