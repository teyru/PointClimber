using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointTrigger : MonoBehaviour
{
    private bool _isOnPlatform;
    private bool _isOnWinPlatform;

    public bool IsOnPlatform { get { return _isOnPlatform; } }
    public bool IsOnWinPlatform { get { return _isOnWinPlatform; } }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Platform")
        {
            _isOnPlatform = true;
        }

        if (other.gameObject.layer == 6)
        {
            _isOnWinPlatform = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Platform")
        {
            _isOnPlatform = false;
        }

        if (other.gameObject.layer == 6)
        {
            _isOnWinPlatform = false;
        }
    }
}
