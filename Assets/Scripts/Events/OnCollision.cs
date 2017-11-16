using UnityEngine;

public class OnCollision : MonoBehaviour
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

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == playerTag)
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

	void OnCollisionStay(Collision collision)
	{
		if (collision.gameObject.tag == playerTag)
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

	void OnCollisionExit(Collision collision)
	{
		if (collision.gameObject.tag == playerTag)
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
