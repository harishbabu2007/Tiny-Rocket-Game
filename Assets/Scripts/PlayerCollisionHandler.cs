using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisionHandler : MonoBehaviour
{
	void OnCollisionEnter(Collision collision)
	{
		string tag = collision.gameObject.tag;

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

	void StartSuccessSequence()
	{
		this.gameObject.GetComponent<PlayerController>().enabled = false;
		Invoke("ReloadNextScene", 1f);
	}

	void StartCrashSequence()
	{
		this.gameObject.GetComponent<PlayerController>().enabled = false;
		Invoke("ReloadThisScene", 1f);
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
