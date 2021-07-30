using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody RocketBody;
    [SerializeField] float thrustForce, rotationForce;
    AudioSource RocketSound;

    void Start()
    {
        RocketBody = GetComponent<Rigidbody>();
        RocketSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame 
    void Update()
    {
        RocketThrust();
        RocketRotation();
    }

    void RocketThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            RocketBody.AddRelativeForce(0f, thrustForce * Time.deltaTime, 0f);
            if (!RocketSound.isPlaying)
            {
                RocketSound.Play();
            }            
        } else
		{
            RocketSound.Stop();
		}
    }

	void RocketRotation()
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationForce);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationForce);
        }
    }

    private void ApplyRotation(float _rotationForce)
    {
        RocketBody.freezeRotation = true;
        transform.Rotate(Vector3.forward * _rotationForce * Time.deltaTime);
        RocketBody.freezeRotation = false;
    }
}
