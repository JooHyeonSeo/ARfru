using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawn : MonoBehaviour
{
    public Transform[] pos; //위치값만 가져오려고
    public GameObject[] prefab;
    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        StartCoroutine(WaitAndSpawn()); // 코르틴 - 동시에 실행하는 함수, 
    }
    IEnumerator WaitAndSpawn()
    {
        while (true)
        {
            //프리팹 과일을 가져와서 과일을 3번 만듬/ 과일을 위로 올라오게 
            float waitTime = Random.Range(2.9f, 4.0f);
            yield return new WaitForSeconds(waitTime); //조건을 만족하지 않으면 밑에있는게 실행 안함
            //기다려라 기다린다음 과일 3개만듬 그리고 소리
            for (int i = 0; i < 8; i++)
            {
                int iPrefab = Random.Range(0, prefab.Length);// 0~3 배열의 개
                int iPos = Random.Range(0, pos.Length);

                GameObject obj = Instantiate(prefab[iPrefab], pos[iPos].position, Quaternion.identity);

                //Quaternion.identity , 회전상태


                Destroy(obj, 5f); // 5초있다가 삭제해

                Rigidbody rb = obj.GetComponent<Rigidbody>();

                rb.AddForce(Vector3.up * Random.Range(8.0f, 15.0f), ForceMode.VelocityChange);          

            }
            audio.Play();
        }
    } 
}
