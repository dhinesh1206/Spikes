using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

public class RingCreator : MonoBehaviour
{
    public int number, obstaclesCount;
    public float radius;
    public Transform center;
    public GameObject brick;
    public List<GameObject> bricks;

    public void Start()
    {
        var parent = new GameObject("ring");
        for (int i = 0; i < number; i++)
        {
            float angle = i * Mathf.PI * 2 / number;
            Vector3 pos = new Vector3(Mathf.Cos(angle) * radius, center.position.y, Mathf.Sin(angle) * radius);
            var instance = Instantiate(brick, pos, Quaternion.identity);
            var direction = center.position - instance.transform.position;
            var turnAngle = Vector3.Angle(direction, instance.transform.right);
            var rotation = new Vector3(0, turnAngle, 0);
            instance.transform.localEulerAngles = rotation;
            CheckRotation(instance.transform, direction, rotation);
            instance.transform.SetParent(parent.transform);
            bricks.Add(instance);
        }
        parent.transform.eulerAngles = new Vector3(90, 0, 0);
    }

    private void CheckRotation(Transform instance, Vector3 direction, Vector3 rotation)
    {
        if (Vector3.Angle(direction, instance.right) > 1)
        {
            rotation = -rotation;
            instance.localEulerAngles = rotation;
        }
    }
}
