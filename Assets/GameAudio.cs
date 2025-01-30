using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudio : MonoBehaviour
{
    public AudioSource audioPlayer;
    public AudioSource audioPlay;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayJumpSE()
    {
        audioPlayer.Play();
    }

    public void PlayGetCoinSE()
    {
        audioPlay.Play();
    }
}
