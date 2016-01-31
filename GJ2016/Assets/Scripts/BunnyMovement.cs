using UnityEngine;
using System.Collections;

public class BunnyMovement : MonoBehaviour {

	public float moveSpeed = 5;
	public float moveSpeedSmooth = 0.3f;
	public float rotateSpeed = 180;
	public float rotateSpeedSmooth = 0.3f;
	public float jumpSpeed = 20;
	public float gravity = 9.8f;

	float currentForwardSpeed;
	float forwardSpeedV;

	float targetRotation;
	float currentRotation;
	float rotationV;


	CharacterController controller;
	Vector3 currentMovement;

	void Start () 
	{
		controller = GetComponent<CharacterController>();

	}
	

	void Update () 
	{

		//transform.Rotate(0, Input.GetAxisRaw("Horizontal") * rotateSpeed * Time.deltaTime, 0);

		targetRotation += Input.GetAxisRaw("Horizontal") * rotateSpeed * Time.deltaTime;
		if (targetRotation > 360)
			targetRotation -= 360;
		if (targetRotation < 0)
			targetRotation += 360;
		currentRotation = Mathf.SmoothDampAngle(currentRotation, targetRotation, ref rotationV, rotateSpeedSmooth);
		transform.eulerAngles = new Vector3(0, currentRotation, 0);


		currentForwardSpeed = Mathf.SmoothDamp(currentForwardSpeed, Input.GetAxisRaw("Vertical") * moveSpeed, ref forwardSpeedV, moveSpeedSmooth);

		currentMovement = new Vector3 (0, currentMovement.y, currentForwardSpeed);
		currentMovement = transform.rotation * currentMovement;

		if (!controller.isGrounded)
			currentMovement -= new Vector3 (0, gravity * Time.deltaTime, 0);
		else
			currentMovement.y = 0;
	
		if (controller.isGrounded && Input.GetButtonDown ("Jump"))
			currentMovement.y = jumpSpeed;


		controller.Move (currentMovement * Time.deltaTime);
			}
}		                                                        
	