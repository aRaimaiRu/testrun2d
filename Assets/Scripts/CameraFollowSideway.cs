using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowSideway : MonoBehaviour
{
    public GameObject player;
    public Vector3 Offset;

    // Start is called before the first frame update
    void Start()
    {
        if(!player) player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x+Offset.x, Offset.y, Offset.z);
    }
}
