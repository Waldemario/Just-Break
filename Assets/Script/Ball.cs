
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle1;
	[SerializeField] float yPush = 15f;
	bool hasStarted = false;
	[SerializeField] AudioClip[] ballSounds;
	[SerializeField] float randomFactor = 0.2f;
	[SerializeField] float magnetto;

	AudioSource myAudioSource;
	Rigidbody2D myRigidbody2D;

    Vector2 paddleToBallVector;
    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
		myAudioSource = GetComponent<AudioSource>();
		myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
	{
		if (!hasStarted)
		{
			StickToPedal();
			LaunchOnClick();
		}
		
	}

	private void LaunchOnClick()
	{
		if (Input.GetMouseButtonDown(0))
		{
			myRigidbody2D.velocity = new Vector2(Random.Range(-2f,2f), yPush);
			hasStarted = true;
			//Rigidbody2D.velocity = new Vector2(2f, 15f);
		}
	}

	private void StickToPedal()
	{
		
			Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
			transform.position = paddlePos + paddleToBallVector;
		
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		AudioSource[] sounds = GetComponents<AudioSource>();
		if (hasStarted)
		{
			AudioClip clip = ballSounds[Random.Range(0, ballSounds.Length)];
			myAudioSource.PlayOneShot(clip);
			TweakVelocity(); 
		}
	}

	private void TweakVelocity()
	{
		float velocityTweak = Random.Range(0f, randomFactor);

		 if (System.Math.Abs(myRigidbody2D.velocity.x) > System.Math.Abs(myRigidbody2D.velocity.y))
		{
			if (myRigidbody2D.velocity.y >= 0)
			{
				myRigidbody2D.velocity += new Vector2(0, velocityTweak);
			}
			else
			{
				myRigidbody2D.velocity += new Vector2(0, -velocityTweak);
			}
		}
		else
		{
			if (myRigidbody2D.velocity.x >= 0)
			{
				myRigidbody2D.velocity += new Vector2(velocityTweak, 0);
			}
			else
			{
				myRigidbody2D.velocity += new Vector2(-velocityTweak, 0);
			}
		} 
		magnetto = myRigidbody2D.velocity.magnitude;
		myRigidbody2D.velocity = myRigidbody2D.velocity.normalized * 10;
	}

	private float rectDiagonal(float a, float b)
	{
		return (float)System.Math.Sqrt(a * a + b * b);
	}
}
