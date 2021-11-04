using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    [SerializeField] private KeyCode keycode;
    private VideoPlayer player;

    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keycode))
        {
            player.playbackSpeed = (player.playbackSpeed + 1)% 2;
        }
            
    }
}
