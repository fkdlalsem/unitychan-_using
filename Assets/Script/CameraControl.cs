using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject target;
    GameObject parent;

    Vector3 defPosition;
    Quaternion defRotation;
    float defZoom;

    void Start()
    {
        parent = transform.parent.gameObject;

        defPosition = target.transform.position;
        defRotation = target.transform.rotation;
        defZoom = Camera.main.fieldOfView;
    }
    // Update is called once per frame
    void Update()
    {
        //오른쪽클릭 왼쪽클릭 방향과 위치변경
        if (Input.GetMouseButton(0))
        {
            target.transform.Translate(-Input.GetAxis("Mouse X") / 10, Input.GetAxis("Mouse Y") / 10, 0);
        }
        if (Input.GetMouseButton(1))
        {
          target.transform.Rotate(-Input.GetAxis("Mouse Y") * 10, -Input.GetAxis("Mouse X") * 10, 0);
        }

        //스크롤 확대 축소
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            Camera.main.fieldOfView += (20 * Input.GetAxis("Mouse ScrollWheel"));

            if (Camera.main.fieldOfView < 10)
                Camera.main.fieldOfView = 10;
            if (Camera.main.fieldOfView > 100)
                Camera.main.fieldOfView = 100;
        }


        //휠버튼 누르면 기본값으로 돌아옴
        if (Input.GetMouseButton(2))
        {
            target.transform.position = defPosition;
            target.transform.rotation = defRotation;
            Camera.main.fieldOfView = defZoom;
        }
    }

}
