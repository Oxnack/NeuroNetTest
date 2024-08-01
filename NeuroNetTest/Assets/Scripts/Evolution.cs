using System.Collections;
using UnityEngine;

public class Evolution : MonoBehaviour
{
    [SerializeField] private GameObject _Anton;
    [SerializeField] private float _time = 5f;

    private GameObject[] _Antons = new GameObject[20];

    private float[] _bestMass1 = new float[4];
    private float[] _bestMass2 = new float[2];

    private JsonSave _jsonSave = new JsonSave();

    public int generation = 1;

    private void Start()
    {
        if (_jsonSave.LoadData() != null)
        {
            NeuroNetData data = _jsonSave.LoadData();
            _bestMass1 = data.bestMass1;
            _bestMass2 = data.bestMass2;
            generation = data.generation;
        }

        generation = _Anton.GetComponent<Model_1>().generation;
        for (int i = 0; i < _Antons.Length; i++)
        {
            _Antons[i] = Instantiate(_Anton, new Vector3(-8, 2.5f, -11.5f), new Quaternion(0, 0, 0, 0));
        }
        StartCoroutine(Eteration());
        Time.timeScale = 3f;
    }

    private void MaxObj()
    {
        generation++;
        GameObject bestObj = FindObjectWithMinDistance();
        _bestMass1 = bestObj.GetComponent<Model_1>()._mass1;
        _bestMass2 = bestObj.GetComponent<Model_1>()._mass2;

        _jsonSave.SaveData(new NeuroNetData {bestMass1 = _bestMass1, bestMass2 = _bestMass2, generation = this.generation});

        foreach (GameObject obj in _Antons)
        {
            Destroy(obj);
        }

        for (int i = 0; i < _Antons.Length; i++)
        {
            GameObject anton = Instantiate(_Anton);
            anton.GetComponent<Model_1>()._mass1 = _bestMass1;
            anton.GetComponent<Model_1>()._mass2 = _bestMass2;
            anton.GetComponent<Model_1>().generation = generation;

            _Antons[i] = Instantiate(anton, new Vector3(-8, 2.5f, -11.5f), new Quaternion(0, 0, 0, 0));
        }
        StartCoroutine(Eteration());
    }

    private GameObject FindObjectWithMinDistance()
    {
        GameObject minObject = _Antons[0];
        float minDistance = float.MaxValue; // �������������� ������������ ���������

        for (int i = 0; i < _Antons.Length; i++)
        {
            if (_Antons[i] != null) // ���������, ��� ������ �� ����� null
            {
                InputNeuro inputNeuro = _Antons[i].GetComponent<InputNeuro>();
                if (inputNeuro != null) // ���������, ��� ��������� ����������
                {
                    float distance = inputNeuro.distanceFinish;
                    if (distance < minDistance && inputNeuro.life != false) // ���� ����������� ��������
                    {
                        minDistance = distance;
                        minObject = _Antons[i];
                    }
                }
            }
        }

        return minObject;
    }

    private IEnumerator Eteration()
    {
        yield return new WaitForSeconds(_time);
        MaxObj();
    }
}
