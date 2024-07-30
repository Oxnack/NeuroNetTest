using UnityEngine;

public class OutputNeuro : MonoBehaviour
{
    public int[] legs = new int[2];

    [SerializeField] private GameObject[] _legs = new GameObject[2];

    [SerializeField] private float _speedRotate = 1f;
    


    private void Update()
    {
        _legs[0].transform.Rotate(legs[0] * _speedRotate * Time.deltaTime, 0, 0);
        _legs[1].transform.Rotate(legs[1] * _speedRotate * Time.deltaTime, 0, 0);
    }

}
