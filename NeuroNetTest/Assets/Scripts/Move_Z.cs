using UnityEngine;

public class Move_Z : MonoBehaviour
{
    [SerializeField] private float  _speed = 1f;
    private void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }
}
