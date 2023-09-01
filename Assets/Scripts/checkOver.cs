using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class checkOver : MonoBehaviour
{
    public VideoPlayer vid;

    void Start() {
        vid = GetComponent<VideoPlayer>(); 
        vid.loopPointReached += CheckOver;
    }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene("_Main Menu");
    }
}
