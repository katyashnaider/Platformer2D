using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegionPatrolling : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;
    [SerializeField] private FlipEnemy _flipTheEnemy;

    private Transform[] _points;

    private int _currentPoint;
    private bool _isFacingRight = true;

    private void Start()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }

    private void Update()
    {
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        Transform target = _points[_currentPoint];

        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, target.position) < 0.2f)
        {
            _currentPoint++;

            if (_currentPoint >= _points.Length)
                _currentPoint = 0;

            if (!_isFacingRight)
                _flipTheEnemy.FlipOver();
            else if (_isFacingRight)
                _flipTheEnemy.FlipOver();
        }
    }
}
