using UnityEngine;
using System.Collections;

public class CheckPointController : MonoBehaviour {

    /*
    Assignment 2 - Chris Gelinas - 300844877 - Date of Modifaction Oct 26, 2016
    */

    //PRIVATE INSTANCE VARIABLE
    private Transform _transform;

    public Transform SpawnPoint;

	// Use this for initialization
	void Start () {
        this._transform = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag ("Player"))
        {
            this.SpawnPoint.position = this._transform.position;
        }
    }
}
