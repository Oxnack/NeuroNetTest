using UnityEngine;

public class NeuroMove : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private bool _human = false;

    private Rigidbody _rb;

    public float x;
    public float z;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_human == true)
        {
            x = Input.GetAxis("Horizontal");
            z = Input.GetAxis("Vertical");
        }


        Vector3 movement = new Vector3(x, 0.0f, z);

        _rb.MovePosition(transform.position + movement * _speed * Time.fixedDeltaTime);
    }
}
