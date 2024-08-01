using UnityEngine;

public class Input_Model_2 : MonoBehaviour
{
    [SerializeField] private GameObject _button;
    [SerializeField] private GameObject _door;

    public float[] input = new float[6];

    private void Start()
    {
        input[0] = _door.transform.position.x;
        input[1] = _door.transform.position.z;
        input[2] = _button.transform.position.x;
        input[3] = _button.transform.position.z;
    }

    private void Update()
    {
        input[4] = transform.position.x;
        input[5] = transform.position.z;
    }

}
