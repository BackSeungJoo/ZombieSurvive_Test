using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PlayerRotate : MonoBehaviour
{
    //public Animator animator;
    Camera characterCamera;

    private void Awake()
    {
        characterCamera = GetComponent<Camera>();
    }

    private void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 moveVector = new Vector3(moveX, 0f, moveZ);
        // ���� ������ ���̰� 0�� �ƴϸ� Ű �Է��� ������ ������ ����
        bool isMove = moveVector.magnitude > 0;
        // �ִϸ������� isMove�� ���� ���� ������ ���̿� ���� �ٲ�� ��
        // animator.SetBool("isMove", isMove);
        LookMouseCursor();

        // ����Ƽ ���� 1 ������ 1����
        transform.Translate(new Vector3(moveX, 0f, moveZ).normalized * Time.deltaTime * 5f);
    }

    public void LookMouseCursor()
    {
        Ray ray = characterCamera.ScreenPointToRay(transform.position);
        RaycastHit hitResult;
        if(Physics.Raycast(ray, out hitResult))
        {
            Vector3 mouseDir = new Vector3(hitResult.point.x, transform.position.y, hitResult.point.z) - transform.position;
            //animator.transform.forward = mouseDir;
        }

    }
}
