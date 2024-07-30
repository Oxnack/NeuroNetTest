using UnityEngine;

public class Model_1 : MonoBehaviour
{
    [SerializeField] private OutputNeuro _outputNeuro;
    [SerializeField] private InputNeuro _inputNeuro;

    public float[] _mass1 = new float[5];
    public float[] _mass2 = new float[2];

    public int generation = 1;


    private void Start()
    {
        for (int i = 0; i < _mass1.Length; i++)
        {
            _mass1[i] = Random.Range(-1f, 1f);
        }
        for (int i = 0; i < _mass2.Length; i++)
        {
            _mass2[i] = Random.Range(-1f, 1f);
        }
    }
    private void Update()
    {
        
    }
}
