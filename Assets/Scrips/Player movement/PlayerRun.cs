

using System.Collections;
using UnityEngine;

public class PlayerRun : MonoBehaviour
{

	public PlayerRunData Data;

	public Animator animator;

	#region COMPONENTS
    public Rigidbody2D RB { get; private set; }
	
	#endregion

	#region STATE PARAMETERS
	
	public bool IsFacingRight { get; private set; }
	public float LastOnGroundTime { get; private set; }
	#endregion

	#region INPUT PARAMETERS
	private Vector2 _moveInput;
	#endregion

	#region CHECK PARAMETERS
	//Set all of these up in the inspector
	[Header("Checks")] 
	[SerializeField] private Transform _groundCheckPoint;
	[SerializeField] private Vector2 _groundCheckSize = new Vector2(0.49f, 0.03f);
	#endregion

	#region LAYERS & TAGS
    [Header("Layers & Tags")]
	[SerializeField] private LayerMask _groundLayer;
	#endregion

	public float KBForce;
	public float KBCounter;
	public float KBTotalTime;
	
	public bool KnockFromRight;




    private void Awake()
	{
		RB = GetComponent<Rigidbody2D>();
	}

	private void Start()
	{
		IsFacingRight = true;
	}

	private void Update()
	{	
		#region TIMERS
        LastOnGroundTime -= Time.deltaTime;
		#endregion

		#region INPUT HANDLER
		_moveInput.x = Input.GetAxisRaw("Horizontal");
			
		animator.SetFloat("Speed", Mathf.Abs(_moveInput.x));

		if (_moveInput.x != 0)
			{CheckDirectionToFace(_moveInput.x > 0);
			}
			else
			{
				if(!IsFacingRight)
				Turn();
			}
		#endregion

		#region COLLISION CHECKS
		//Ground Check
		if (Physics2D.OverlapBox(_groundCheckPoint.position, _groundCheckSize, 0, _groundLayer)) //checks if set box overlaps with ground
			LastOnGroundTime = 0.1f;
		#endregion
    }

    private void FixedUpdate()
	{
		
		if(KBCounter <= 0)
		{
			Run();
			AudioManager.instance.Play("Defeat");
			//GameObject.Find("Music").GetComponent<AudioManager>().Play("Defeat");
		} 
		else 
		{
			if(KnockFromRight == true)
			{
				RB.velocity = new Vector2(-KBForce, KBForce);
			}
			if(KnockFromRight == false)
			{
				RB.velocity = new Vector2(KBForce, KBForce);
			}
			KBCounter -= Time.deltaTime;
		}
    }

	//MOVEMENT METHODS
    #region RUN METHODS
    private void Run()
	{
		//Calculate the direction we want to move in and our desired velocity
		float targetSpeed = _moveInput.x * Data.runMaxSpeed;

		#region Calculate AccelRate
		float accelRate;

		//Gets an acceleration value based on if we are accelerating (includes turning) 
		//or trying to decelerate (stop). As well as applying a multiplier if we're air borne.
		if (LastOnGroundTime > 0)
			accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? Data.runAccelAmount : Data.runDeccelAmount;
		else
			accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? Data.runAccelAmount * Data.accelInAir : Data.runDeccelAmount * Data.deccelInAir;
		#endregion

		//Not used since no jump implemented here, but may be useful if you plan to implement your own
		/* 
		#region Add Bonus Jump Apex Acceleration
		//Increase are acceleration and maxSpeed when at the apex of their jump, makes the jump feel a bit more bouncy, responsive and natural
		if ((IsJumping || IsWallJumping || _isJumpFalling) && Mathf.Abs(RB.velocity.y) < Data.jumpHangTimeThreshold)
		{
			accelRate *= Data.jumpHangAccelerationMult;
			targetSpeed *= Data.jumpHangMaxSpeedMult;
		}
		#endregion
		*/

		#region Conserve Momentum
		//We won't slow the player down if they are moving in their desired direction but at a greater speed than their maxSpeed
		if(Data.doConserveMomentum && Mathf.Abs(RB.velocity.x) > Mathf.Abs(targetSpeed) && Mathf.Sign(RB.velocity.x) == Mathf.Sign(targetSpeed) && Mathf.Abs(targetSpeed) > 0.01f && LastOnGroundTime < 0)
		{
			//Prevent any deceleration from happening, or in other words conserve are current momentum
			//You could experiment with allowing for the player to slightly increae their speed whilst in this "state"
			accelRate = 0; 
		}
		#endregion

		//Calculate difference between current velocity and desired velocity
		float speedDif = targetSpeed - RB.velocity.x;
		//Calculate force along x-axis to apply to thr player

		float movement = speedDif * accelRate;

		//Convert this to a vector and apply to rigidbody
		RB.AddForce(movement * Vector2.right, ForceMode2D.Force);

		
	}

	private void Turn()
	{
		//stores scale and flips the player along the x axis, 
		transform.Rotate(0f, 180f, 0f);

		IsFacingRight = !IsFacingRight;
	}
    #endregion


    #region CHECK METHODS
    public void CheckDirectionToFace(bool isMovingRight)
	{
		if (isMovingRight != IsFacingRight)
			Turn();
	}
    #endregion

}

