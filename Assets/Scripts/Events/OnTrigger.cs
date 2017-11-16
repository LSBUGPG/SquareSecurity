using UnityEngine;

public class OnTrigger : MonoBehaviour
{
	public string playerTag = "Player";
	public AudioSource audioSource;
	public bool playSoundOnEnter, playSoundOnStay, playSoundOnExit = false;

	void Awake()
	{
		if (audioSource == null)
		{
			Debug.Log("Can't find Audio Source.");
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == playerTag)
		{
			if (playSoundOnEnter)
			{
				if (audioSource != null && !audioSource.isPlaying)
				{
					audioSource.Play();
				}
			}
		}
	}

	void OnTriggerStay(Collider other)
	{
		if (other.tag == playerTag)
		{
			if (playSoundOnStay)
			{
				if (audioSource != null && !audioSource.isPlaying)
				{
					audioSource.Play();
				}
			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == playerTag)
		{
			if (playSoundOnExit)
			{
				if (audioSource != null && !audioSource.isPlaying)
				{
					audioSource.Play();
				}
			}
		}
	}
}
