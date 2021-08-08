using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody RocketBody;
    [SerializeField] float thrustForce, rotationForce;
    AudioSource RocketSound;

    [SerializeField] AudioClip BoostSound;
    [SerializeField] ParticleSystem JetParticles, LeftParticle, RightParticle;

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
                JetParticles.Play();
                RocketSound.PlayOneShot(BoostSound);
            }            
        } else
		{
            JetParticles.Stop();
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
        } else
		{
            LeftParticle.Stop();
            RightParticle.Stop();
		}
    }

    private void ApplyRotation(float _rotationForce)
    {
        if (_rotationForce > 0)
		{
            LeftParticle.Play();
		} else if (_rotationForce < 0)
		{
            RightParticle.Play();
		}
        RocketBody.freezeRotation = true;
        transform.Rotate(Vector3.forward * _rotationForce * Time.deltaTime);
        RocketBody.freezeRotation = false;
    }
}
