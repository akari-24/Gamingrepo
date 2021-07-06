using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	//Movement Variables
	[Header("Movement Variables")]
	public float speed;

	//Jumping Variables
	[Header("Jumping Variables")]
	public float yForce;

	public float yGravity;

	public float maxGravity;

	public float jumpspeed;

	public bool isjumping;

	// Refrences
	[Header("Refrences")]
	DoubleJump doubleJump;
	CharacterController myController;
    // Start is called before the first frame update

    void Start()
    {
        //Adding a value to CharacterController
        myController = GetComponent<CharacterController>();
        doubleJump = GetComponent<DoubleJump>();
    }

    // Update is called once per frame
    void Update()
    {
       //Setting keybinds for movement
       if(Input.GetKey(KeyCode.W))
        {
        	MoveForward();
    	}

    	if(Input.GetKey(KeyCode.S))
    	{
    		MoveBack();
    	}

    	if(Input.GetKey(KeyCode.A))
    	{
    		MoveLeft();
    	}

    	if(Input.GetKey(KeyCode.D))
    	{
    		MoveRight();
    	}

    	if(Input.GetKeyDown(KeyCode.Space))
    	{
    		if(!isjumping)
    		{
    			Jump();
    		}
    		else 
    		{
    			if(doubleJump.available)
    			{
    				doubleJump.available = false;
    				Jump();
    			}
    		}
    	}

    	if(myController.isGrounded && yForce < 0)
    		{
    			isjumping = false;
    			doubleJump.available = true;

    		}

    	if(!myController.isGrounded)
    		{
    			yForce = Mathf.Max(maxGravity, yForce + (yGravity * Time.deltaTime));
    		}


    		//Apply y-Force to a character
    		myController.Move(Vector3.up * yForce * Time.deltaTime);

    }

    void MoveForward()
    {
    	myController.Move(Vector3.forward * Time.deltaTime * speed);
    }

    void MoveBack()
    {
    	myController.Move(Vector3.back * Time.deltaTime * speed);
    }

    void MoveLeft()
    {
    	myController.Move(Vector3.left * Time.deltaTime * speed);
    }

    void MoveRight()
    {
    	myController.Move(Vector3.right * Time.deltaTime * speed);
    }

    void Jump()
    {
    	yForce = jumpspeed;
    	isjumping = true;
    }
}


