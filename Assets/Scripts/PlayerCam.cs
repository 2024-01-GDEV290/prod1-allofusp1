using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCam : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;

    float xRotation;
    float yRotation;
    [SerializeField] float bottomClamp =-90f;
    [SerializeField] float topClamp = 90f;
    public bool finalCam = false;
    // Start is called before the first frame update
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    // Update is called once per frame
    private void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, bottomClamp, topClamp);
        if(finalCam)
        {
            xRotation = Mathf.Clamp(xRotation, -20f, 30f);
            yRotation = Mathf.Clamp(yRotation, 40f, 100f);
        }

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);

    }
    private IEnumerator StartingSet()
    {
        yield return new WaitForSeconds(3); 
    }

}
