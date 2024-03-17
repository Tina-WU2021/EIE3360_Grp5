using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject thirdPersonPlayer;    //��ɫ
    public GameObject FollowCamera;         //�������
    public float CameraSmoothTime = 0;
    public float RotateSpeed;
    private Vector3 velocity = Vector3.zero;
    void Update()
    {
        //���������ת
        float x = RotateSpeed * Input.GetAxis("Mouse X");
        //����Ϊ������ɫͬ����ת��
        FollowCamera.transform.rotation = Quaternion.Euler(
            FollowCamera.transform.rotation.eulerAngles +
            Quaternion.AngleAxis(x, Vector3.up).eulerAngles
        );//ԭ�� ���嵱ǰ��ŷ���� + ���x���ϵ������������ļн�

        thirdPersonPlayer.transform.rotation = Quaternion.Euler(
            thirdPersonPlayer.transform.rotation.eulerAngles +
            Quaternion.AngleAxis(x, Vector3.up).eulerAngles
        );//ͬ��
          //------------------------------------------------------>>>>>>>>
          //��������ƶ�
        Vector3 TargetCameraPosition = thirdPersonPlayer.transform.TransformPoint(new Vector3(0, 4.5f, -5.5f));//��ȡ�����������λ�ã���תΪ��������

        FollowCamera.transform.position = Vector3.SmoothDamp(
            FollowCamera.transform.position,
            TargetCameraPosition,
            ref velocity,
            CameraSmoothTime, //���Ϊ0
            Mathf.Infinity,
            Time.deltaTime
        );
    }
   
}
