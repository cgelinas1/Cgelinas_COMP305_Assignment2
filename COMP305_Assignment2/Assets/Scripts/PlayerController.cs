using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    /*
    Assignment 2 - Chris Gelinas - 300844877 - Date of Modifaction Oct 24, 2016
    PlayerController v.2
    */



    //PRIVATE INSTANCE VARIABLES\
    private Transform _transform;
    private Rigidbody2D _rigidbody;
    private float _move;
    private float _jump;
    private bool _isFacingRight; //check if player facing right
    private bool _isGrounded; // check if grounded for falling and jumping


    // Public Instance Variables
    public float Velocity = 10f;
    public float JumpForce = 100f;

    //public Camera camera;

    // Use this for initialization
    void Start() {
        this._initialize();
    }

    // Update is called once per frame (Physics)
    void FixedUpdate()
    {
        // check if input is present for movement

        if (this._isGrounded)
        {
            // check if input is present for movement
            this._move = Input.GetAxis("Horizontal");
            if (this._move > 0f)
            {
                this._move = 1;
                this._isFacingRight = true;
                this._flip();
            }
            else if (this._move < 0f)
            {
                this._move = -1;
                this._isFacingRight = false;
                this._flip();
            }
            else
            {
                this._move = 0f;
            }

            // check if input is present for jumping
            if (Input.GetKeyDown(KeyCode.Space))
            {
                this._jump = 1f;

            }

            this._rigidbody.AddForce(new Vector2(
                this._move * this.Velocity,
                this._jump * this.JumpForce),
                ForceMode2D.Force);

        }
        // no movement or jumping if not grounded
        else
        {
            this._move = 0f;
            this._jump = 0f;
        }
    }

        //this.camera.transform.position = new Vector3 (this._transform.position.c, this._transfrom.position.y, -10f)

        //Private Methods
        //initialize variables when object called
    public void _initialize() {
		this._transform = GetComponent<Transform> ();
		this._rigidbody = GetComponent<Rigidbody2D> ();
		this._move = 0f;
        this._isFacingRight = true;
        this._isGrounded = false;
	}

    //method flips characfter's bitmap across x-axis

    private void _flip ()
    {
        if (this._isFacingRight)
        {
            this._transform.localScale = new Vector2(1f, 1f);
        }
        else
        {
            this.transform.localScale = new Vector2 ( -1f, 1f );
        }

       
    }

     private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag ("Platform"))
        {
            this._isGrounded = true; //checks if player is grounded (on platform)
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        this._isGrounded = false;       //checks if player jumping or in freefall
    }
}
