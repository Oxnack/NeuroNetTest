using UnityEngine;

public class InputNeuro : MonoBehaviour
{
    [SerializeField] private GameObject _finish;
    [SerializeField] private GameObject _left;
    [SerializeField] private GameObject _right;

    private Vector3 leftRotaion;
    private Vector3 rightRotaion;
    private Vector3 rotation;

    public float leftRX;
    public float rightRX;
    public float rotationX;

    public float distanceFinish;
    public float height;

    public bool life = true;

    private void Start()
    {
         _finish = GameObject.FindGameObjectWithTag("Finish");
    }


    private void Update()
    {
        Quaternion worldRotation = _left.transform.rotation;
        Quaternion parentWorldRotation = transform.rotation;
        Quaternion localRotation = Quaternion.Inverse(parentWorldRotation) * worldRotation;
        leftRotaion = localRotation.eulerAngles;

        worldRotation = _right.transform.rotation;
        parentWorldRotation = transform.rotation;
        localRotation = Quaternion.Inverse(parentWorldRotation) * worldRotation;
        rightRotaion = localRotation.eulerAngles;

        leftRX = leftRotaion.x;
        rightRX = rightRotaion.x;
        rotationX = rotation.x;

        distanceFinish = Vector3.Distance(transform.position, _finish.transform.position);
        height = transform.position.y;
        rotation = transform.rotation.eulerAngles;
    }
}
