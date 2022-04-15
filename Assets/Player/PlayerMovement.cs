using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Transform _firstPlayerPart;
    [SerializeField] private Transform _secondPlayerPart;

    [SerializeField] private GameObject _platesParticles;
    [SerializeField] private Transform _particleCleaner;

    [SerializeField] [Range(50f,300f)] private float _rotationSpeed = 50f;
    

    private PointTrigger[] trigger;


    private Transform _currentParent;
    private Vector3 _rotationChanger;

    private bool _winPointReached;

    public bool WinPointReached { get { return _winPointReached; } }


    void Start()
    {
        trigger = FindObjectsOfType<PointTrigger>();
        _rotationChanger = Vector3.down;

        _currentParent = _firstPlayerPart;
        _secondPlayerPart.parent = _firstPlayerPart;
    }

    private void ChangeParent()
    {
        if(_currentParent == _secondPlayerPart)
        {
            SetNewParent(_firstPlayerPart);
        }
        else
        {
            SetNewParent(_secondPlayerPart);
        }        
    }

    private void SetNewParent(Transform activePart)
    {
        activePart.parent = gameObject.transform;
        _currentParent.parent = activePart;
        _currentParent = activePart;
        GameObject particles = Instantiate(_platesParticles, _currentParent.position, Quaternion.Euler(0f, 90f, 0f));
        particles.transform.parent = _particleCleaner;
        _rotationChanger = -_rotationChanger;
    }


    void Update()
    {
        RotationByPart();
        if (Input.GetMouseButtonDown(0))
        {
            foreach (PointTrigger trig in trigger)
            {
                if (!trig.IsOnPlatform)
                {
                    Destroy(gameObject);
                    return;
                }
                if (trig.IsOnWinPlatform)
                {
                    _winPointReached = true;
                }
            }
            

            ChangeParent();
        }
    }

    private void RotationByPart()
    {
        _currentParent.transform.Rotate(_rotationChanger * Time.deltaTime * _rotationSpeed);
    }



}
