using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;

    [SerializeField] private float y = 2.0f;
    [SerializeField] private float z = -2.5f;

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + new Vector3(0, y-0.15f, z);
    }
}
