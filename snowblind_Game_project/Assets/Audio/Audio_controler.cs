using UnityEngine;
using System.Collections;

public class Audio_controler : MonoBehaviour {

    public AudioSource Speaker;
    public AudioClip drum;
    public AudioClip woodChop;
    public AudioClip hammer;
    public AudioClip saplings;
    public AudioClip mineRock;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PlayDrum()
    {
        Speaker.PlayOneShot(drum);
    }

    public void PlayWoodChop()
    {
        Speaker.PlayOneShot(woodChop);
    }

    public void PlayHammer()
    {
        Speaker.PlayOneShot(hammer);
    }

    public void PlayCollectSaplings()
    {
        Speaker.PlayOneShot(saplings);
    }

    public void PlayMineRock()
    {
        Speaker.PlayOneShot(mineRock);
    }
}
