using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject camera;
    public GameObject prefab;

    public int scorePerFruit = 10;
    AudioSource audio;
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void Fire()
    {
        RaycastHit hit;
        //RaycastHit: �������� ������ ��, ������ ��ü�� �ε����� �� ���� ����

        //�ε����� if�� ����
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit))    
        {
            if (hit.transform.tag == "Fruit")
            {
                Destroy(hit.transform.gameObject);
                Instantiate(prefab, hit.point, Quaternion.LookRotation(hit.normal));             
                audio.Play();

                GameManager.Instance.AddScore(scorePerFruit);
            }
        }
    }   
}
