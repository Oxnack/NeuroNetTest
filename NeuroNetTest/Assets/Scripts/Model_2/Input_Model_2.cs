using UnityEngine;

public class Input_Model_2 : MonoBehaviour
{
    [SerializeField] private GameObject _button;
    [SerializeField] private GameObject _door;
    [SerializeField] private GameObject _Qute;

    public float[] input = new float[8];

    private void Start()
    {
        input[0] = _door.transform.position.x;
        input[1] = _door.transform.position.z;
        input[2] = _button.transform.position.x;
        input[3] = _button.transform.position.z;
        input[4] = _Qute.transform.position.x;
        input[5] = _Qute.transform.position.z;
    }

    private void Update()
    {
        input[6] = transform.position.x;
        input[7] = transform.position.z;
    }

}
