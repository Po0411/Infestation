using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombie : MonoBehaviour
{
    public GameObject objectToSpawn; // ��ȯ�� ������Ʈ�� �������� �����ϱ� ���� ����

    public float spawnInterval = 2.0f; // ��ȯ ����
    public float spawnRadius = 5.0f; // ��ȯ�� ��ġ�� �ݰ�

    private float timeSinceLastSpawn = 0.0f;

    void Update()
    {
        // �ð��� spawnInterval �̻� ������� ��
        if (timeSinceLastSpawn >= spawnInterval)
        {
            // ������ ��ġ ���
            Vector3 randomPosition = transform.position + Random.insideUnitSphere * spawnRadius;
            // Y ��ǥ�� �����Ͽ� ���� ���� ��ȯ�ǵ��� ��
            randomPosition.y = 0;

            // ������Ʈ ��ȯ
            Instantiate(objectToSpawn, randomPosition, Quaternion.identity);

            // �ð� �ʱ�ȭ
            timeSinceLastSpawn = 0.0f;
        }
        else
        {
            // �ð� ������Ʈ
            timeSinceLastSpawn += Time.deltaTime;
        }
    }
}
