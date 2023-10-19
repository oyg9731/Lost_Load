using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]

public class Control : MonoBehaviour
{
    private float h = 0.0f;
    private float v = 0.0f;
    private float rotationX = 0.0f; // 새로 추가된 회전 변수
    private float rotationSpeed = 500.0f;
    private float moveSpeed = 7.3f;
    private Transform playerTr;
    private int keyCount = 0;
    public AudioClip keySfx;
    private AudioSource audioSource;
    public GameObject doorGroup;
    public GameObject textUI;
    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        playerTr = GetComponent<Transform>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        // 마우스 입력을 사용하여 회전을 부드럽게 처리
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        rotationX -= Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
        rotationX = Mathf.Clamp(rotationX, -90, 90); // 상하 회전 각도 제한

        // 회전 적용
        playerTr.Rotate(Vector3.up * mouseX);
        Camera.main.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);

        playerTr.Translate(new Vector3(h, 0, v) * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Key")
        {
            Destroy(collision.gameObject);
            keyCount++;
            Debug.Log("Key : " + keyCount.ToString());
            audioSource.PlayOneShot(keySfx, 1.0f);
            textUI.GetComponent<Text>().text = "현재 찾은 열쇠 갯수 : " + keyCount.ToString();
        }
        if (collision.gameObject.tag == "DOOR" && keyCount >= 3)
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Portal")
        {
            SceneManager.LoadScene("Main");
        }
    }
}
