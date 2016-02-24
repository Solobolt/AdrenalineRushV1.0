using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private Transform myTransform;

    //Holds all speed Variables
    private float speedIncrease = 30.0f;
    public float currentSpeed = 0;
    private float maxSpeed = 50.0f;
    private float speedDelta = 100.0f;

    //holds the players distnace from the begining distance
    private float distance = 0.0f;

    // Use this for initialization
    void Start () {
        myTransform = this.transform;
    }
	
	// Update is called once per frame
	void Update () {
        //constant speed degredation
        currentSpeed -= speedDelta * Time.deltaTime;

        //stops player from moving backwards
        if (currentSpeed < 0)
        {
            currentSpeed = 0;
        }

        //Handles mouse click
        if (Input.GetMouseButtonDown(0))
        {
            currentSpeed += speedIncrease;
            if(currentSpeed >= maxSpeed)
            {
                currentSpeed = maxSpeed;
            }
        }

        //Moves the player at the cirrect speed
        myTransform.Translate(Vector3.right * Time.deltaTime * currentSpeed);

        //Tracks the players current distance
        distance += Time.deltaTime * currentSpeed;

        //Creates new floor every 100 m
        if (distance > 100)
        {
            distance -= 100;
            print("Create Floor");
            //Create a floor
        }
    }
}
