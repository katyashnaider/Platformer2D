using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsSpawn : MonoBehaviour
{
    [SerializeField] private Transform[] _points;
    [SerializeField] private Coin _coin;

    private Coroutine _coroutine;

    private void Start()
    {
        _coroutine = StartCoroutine(CoinSpawn());
    }

    private IEnumerator CoinSpawn()
    {
        foreach (var point in _points)
        {
            Instantiate(_coin, point.transform.position, Quaternion.identity);

            yield return _coin;
        }
    }
}
