using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisionHandler : MonoBehaviour
{

	AudioSource Mainplayer;
	[SerializeField] AudioClip SuccessSound, DieSound;
	[SerializeField] float DeathsoundIntensity;
	[SerializeField] ParticleSystem SuccessParticles, DeathParticles;
	[SerializeField] AudioSource Ambience;

	bool isTransitioning = false;

	void Start()
	{
		Mainplayer = GetComponent<AudioSource>();	
	}

	void OnCollisionEnter(Collision collision)
	{
		string tag = collision.gameObject.tag;

		if (!isTransitioning)
		{
			switch (tag)
			{
				case "Obstacle":
					StartCrashSequence();
					break;

				case "Ground":
					StartCrashSequence();
					break;

				case "Finish":
					StartSuccessSequence();
					break;
			}
		}
	}

	void StartSuccessSequence()
	{
		SuccessParticles.Play();
		this.gameObject.GetComponent<PlayerController>().enabled = false;
		Invoke("ReloadNextScene", 1f);

		Ambience.Stop();
		Mainplayer.Stop();
		Mainplayer.PlayOneShot(SuccessSound);
		isTransitioning = true;
	}

	void StartCrashSequence()
	{
		DeathParticles.Play();
		this.gameObject.GetComponent<PlayerController>().enabled = false;
		Invoke("ReloadThisScene", 1f);

		Ambience.Stop();
		Mainplayer.Stop();
		Mainplayer.PlayOneShot(DieSound, DeathsoundIntensity);
		isTransitioning = true;
	}

	void ReloadThisScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	void ReloadNextScene()
	{
		int thisScene = SceneManager.GetActiveScene().buildIndex;
		int nextScene = thisScene + 1;
		
		if (nextScene == SceneManager.sceneCountInBuildSettings)
		{
			nextScene = 0;
		}

		SceneManager.LoadScene(nextScene);
	}
}
