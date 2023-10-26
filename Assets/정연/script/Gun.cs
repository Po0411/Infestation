using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Oculus;

public class Gun : MonoBehaviour
{
    public int Damage = 10;
    public AudioClip gun_fire;
    public AudioClip empty_magazine;
    public AudioClip Reroad;

    RaycastHit hit;
    float max_ray = 15f;
    AudioSource audio;

    private OVRInput.Controller controller;

    private void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();//����� �ҽ� �ҷ�����
        controller= OVRInput.Controller.RTouch;
    }

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, controller))//������ ���� Ʈ���� Ű�� ������
        {
            if (GameManager.Game_Mg.burnt_index > 0)//�Ѿ� ������ 0�� ���ϰ� �ƴϸ�
            {
                StartCoroutine(GameManager.Game_Mg.burnt_use());//�Ѿ� �ϳ� ���
                audio.clip = gun_fire;//����� Ŭ���� �� �߻� �Ҹ� ����
                audio.Play();//����� ���
                Debug.DrawRay(transform.position, transform.forward * max_ray, Color.blue, 0.1f);//0.1�� ���� ray�� 15 ������ �Ķ��� �ٷ� ǥ�� 
                if (Physics.Raycast(transform.position, transform.forward, out hit, max_ray))//ray �߻� 
                {
                    if (hit.transform.CompareTag("monster"))//ray�� ���� ������Ʈ�� �±װ� monster��
                    {
                        StartCoroutine(hit.transform.GetComponent<moster_st>().monster_damage(Damage));//���� ������Ʈ�� monster_st���� ���� ������ �Լ� ȣ��
                    }
                }
            }
            else//�Ѿ��� 0�� ���ϸ�
            {
                audio.clip = empty_magazine;//Ŭ���� ��Ҹ� ����
                audio.Play();//�Ҹ� ���
            }

        }
        if(OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, controller) && GameManager.Game_Mg.burnt_index != 5)//�Ѿ��� 5���� �ƴ� ���¿��� ������ Ʈ���� Ű�� ������
        {
            audio.clip = Reroad;//Ŭ���� �������Ҹ� ����
            audio.Play();//����� ���
            GameManager.Game_Mg.burnt_index = 5;//�Ѿ� ���� 5���� 
        }
    }
}
