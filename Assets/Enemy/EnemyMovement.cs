using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform[] _trajectoryPlaces;

    [SerializeField] private float _moveSpeed;

    private int _places = 0;

    private void Update()
    {
        MoveToPoint();
    }

    private void MoveToPoint()
    {
        if (Vector3.Distance(transform.position, _trajectoryPlaces[_places].position) > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, _trajectoryPlaces[_places].position, _moveSpeed * Time.deltaTime);
        }
        else
        if (_places == _trajectoryPlaces.Length - 1)
        {
            _places = 0;
        }
        else
        {
            _places++;
        }
    }

}
