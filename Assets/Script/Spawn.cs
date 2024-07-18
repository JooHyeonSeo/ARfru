using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawn : MonoBehaviour
{
    public Transform[] pos; //��ġ���� ����������
    public GameObject[] prefab;
    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        StartCoroutine(WaitAndSpawn()); // �ڸ�ƾ - ���ÿ� �����ϴ� �Լ�, 
    }
    IEnumerator WaitAndSpawn()
    {
        while (true)
        {
            //������ ������ �����ͼ� ������ 3�� ����/ ������ ���� �ö���� 
            float waitTime = Random.Range(2.9f, 4.0f);
            yield return new WaitForSeconds(waitTime); //������ �������� ������ �ؿ��ִ°� ���� ����
            //��ٷ��� ��ٸ����� ���� 3������ �׸��� �Ҹ�
            for (int i = 0; i < 8; i++)
            {
                int iPrefab = Random.Range(0, prefab.Length);// 0~3 �迭�� ��
                int iPos = Random.Range(0, pos.Length);

                GameObject obj = Instantiate(prefab[iPrefab], pos[iPos].position, Quaternion.identity);

                //Quaternion.identity , ȸ������


                Destroy(obj, 5f); // 5���ִٰ� ������

                Rigidbody rb = obj.GetComponent<Rigidbody>();

                rb.AddForce(Vector3.up * Random.Range(8.0f, 15.0f), ForceMode.VelocityChange);          

            }
            audio.Play();
        }
    } 
}
