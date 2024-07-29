using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Model_0 : MonoBehaviour  // Y-Acsis translate
{
    [SerializeField] private GameObject _finish;
    [SerializeField] private float _speedRotate = 1f;

    private float _lastDistance;

    private void Start()
    {
        _lastDistance = Vector3.Distance(transform.position, _finish.transform.position);
    }

    private void Update()
    {
        if (_lastDistance > Vector3.Distance(transform.position, _finish.transform.position))
        {
            Debug.Log("GoodMove");
        }
        else
        {
            Debug.Log("NO GOD PLEASE NO");
            transform.Rotate(0, _speedRotate * Time.deltaTime, 0);
        }
        

        _lastDistance = Vector3.Distance(transform.position, _finish.transform.position);
    }
}
