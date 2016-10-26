using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {
    /*
   Assignment 2 - Chris Gelinas - 300844877 - Date of Modifaction Oct 26, 2016
   */
    private Transform _transform;
    private Rigidbody2D _rigidbody;
    private bool _isGrounded;
    private bool _isGroundAhead;
    private bool _isPlayerDetected;

    //PUBLIC INSTANCE VARIABLES
    public float Speed = 5f;
    public Transform SightStart;
    public Transform SightEnd;
    public Transform LineOfSight;

	// Use this for initialization
	void Start () {
        this._transform = GetComponent<Transform> ();
        this._rigidbody = GetComponent<Rigidbody2D>();
        this._isGrounded = false;
        this._isGroundAhead = true;
        this._isPlayerDetected = false;
	}
	
	// Update is called once per frame [Physics}
	void FixedUpdate () {

        //check if object is grounded
        if(this._isGrounded)
        {
        //move object in direction of local scale
        this._rigidbody.velocity = new Vector2(this._transform.localScale.x, 0) * this.Speed;

            this._isGroundAhead = Physics2D.Linecast(
                this.SightStart.position,
                this.SightEnd.position,
                1 << LayerMask.NameToLayer("Solid"));

           if (this._isGroundAhead == false)
            {
                //flip enemy direction
                this._flip();
            }

            this._isPlayerDetected = Physics2D.Linecast(
                this.SightStart.position,
                this.SightEnd.position,
                1 << LayerMask.NameToLayer("Player"));

            
            if(this._isPlayerDetected)
            {
                //increase speed to 4
                this.Speed *= 2;
                if (this.Speed >= 4)
                {
                    this.Speed = 4;
                }
            }
        }

        


	}

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            this._isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other) { 
        if(other.gameObject.CompareTag("Platform"))
    {
        this._isGrounded = false;
    }
    }

    private void _flip()
    {
        if (this._transform.localScale.x == 1)
        {
            this._transform.localScale = new Vector2(-1f, 1f);
        }
        else
        {
            this.transform.localScale = new Vector2(1f, 1f);
        }


    }
}
