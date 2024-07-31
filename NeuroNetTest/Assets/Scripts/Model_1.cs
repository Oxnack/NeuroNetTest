using UnityEngine;

public class Model_1 : MonoBehaviour
{
    [SerializeField] private OutputNeuro _outputNeuro;
    [SerializeField] private InputNeuro _inputNeuro;

    public float[] _mass1 = new float[4];
    public float[] _mass2 = new float[2];

    public int generation = 1;

    private float _leftRX;
    private float _rightRX;
    private float _rotationX;
 //   private float _distanceFinish;
    private float _height;

    private int _left = 0;
    private int _right = 0;

    private void Start()
    {
        RandomAll();
    }
    private void Update()
    {
        _leftRX = _inputNeuro.leftRX * _mass1[0];
        _rightRX = _inputNeuro.rightRX * _mass1[1];
        _rotationX = _inputNeuro.rotationX * _mass1[2];
        //_distanceFinish = _inputNeuro.distanceFinish * _mass1[3];
        _height = _inputNeuro.height * _mass1[3];

        float leftFl = (_leftRX + _rightRX + _rotationX + _height) * _mass2[0];
        float rightFl = (_leftRX + _rightRX + _rotationX + _height) * _mass2[1];

        if (leftFl > 1)
        {
            _left = 1;
        }
        else if(leftFl < -1)
        {
            _left = -1;
        }
        else
        {
            _left = 0;
        }

        if (rightFl > 1)
        {
            _right = 1;
        }
        else if (leftFl < -1)
        {
            _right = -1;
        }
        else
        {
            _right = 0;
        }

        Move();
    }

    private void Move()
    {
        _outputNeuro.legs[0] = _left;
        _outputNeuro.legs[1] = _right;
    }

    private void RandomAll()
    {
        Randoming(_mass1);
        Randoming(_mass2);
    }

    private void Randoming(float[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = Random.Range(array[i] - 1f/generation, array[i] + 1f/generation);
        }
    }
}
