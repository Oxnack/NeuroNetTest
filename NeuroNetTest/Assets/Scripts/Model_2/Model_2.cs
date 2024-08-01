using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model_2 : MonoBehaviour
{
    public float learningRate = 0.1f; // α
    public float discountFactor = 0.9f; // γ
    public float explorationRate = 1.0f; // ε
    public float explorationDecay = 0.995f;
    public int maxEpisodes = 1000;
    public int maxSteps = 100;

    private Dictionary<string, float[]> qTable = new Dictionary<string, float[]>();
    private Vector2 targetPosition;

    private void Start()
    {
        targetPosition = new Vector2(Random.Range(-5f, 5f), Random.Range(-5f, 5f));
        StartCoroutine(RunEpisodes());
    }

    private IEnumerator RunEpisodes()
    {
        for (int episode = 0; episode < maxEpisodes; episode++)
        {
            Vector2 startPosition = transform.position;
            for (int step = 0; step < maxSteps; step++)
            {
                string state = GetState();
                int action = ChooseAction(state);
                PerformAction(action);
                float reward = GetReward();
                string newState = GetState();

                UpdateQTable(state, action, reward, newState);

                if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
                    break; // Достигли цели
            }
            explorationRate *= explorationDecay; // Уменьшаем ε
            ResetAgent();
            yield return null;
        }
    }

    private string GetState()
    {
        return $"{transform.position.x},{transform.position.y}";
    }

    private int ChooseAction(string state)
    {
        if (!qTable.ContainsKey(state))
            qTable[state] = new float[4]; // 4 возможных действия: вверх, вниз, влево, вправо

        if (Random.value < explorationRate)
        {
            return Random.Range(0, 4); // Исследуем
        }
        else
        {
            return GetBestAction(state); // Эксплуатируем
        }
    }

    private int GetBestAction(string state)
    {
        float[] actions = qTable[state];
        int bestAction = 0;
        for (int i = 1; i < actions.Length; i++)
        {
            if (actions[i] > actions[bestAction])
                bestAction = i;
        }
        return bestAction;
    }

    private void PerformAction(int action)
    {
        switch (action)
        {
            case 0: // Вверх
                transform.position += Vector3.up * Time.deltaTime;
                break;
            case 1: // Вниз
                transform.position += Vector3.down * Time.deltaTime;
                break;
            case 2: // Влево
                transform.position += Vector3.left * Time.deltaTime;
                break;
            case 3: // Вправо
                transform.position += Vector3.right * Time.deltaTime;
                break;
        }
    }

    private float GetReward()
    {
        float distanceToTarget = Vector2.Distance(transform.position, targetPosition);
        if (distanceToTarget < 0.1f)
            return 10f; // Награда за достижение цели
        else
            return -0.1f; // Наказание за каждоедействие
    }

    private void UpdateQTable(string state, int action, float reward, string newState)
    {
        if (!qTable.ContainsKey(newState))
            qTable[newState] = new float[4];

        float maxFutureQ = Mathf.Max(qTable[newState]);
        qTable[state][action] += learningRate * (reward + discountFactor * maxFutureQ - qTable[state][action]);
    }

    private void ResetAgent()
    {
        transform.position = new Vector2(Random.Range(-5f, 5f), Random.Range(-5f, 5f));
        targetPosition = new Vector2(Random.Range(-5f, 5f), Random.Range(-5f, 5f));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(targetPosition, 0.1f);
    }
}
