using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]

public class Control1 : MonoBehaviour
{
    private float h = 0.0f;
    private float v = 0.0f;
    private float rotationX = 0.0f; // ���� �߰��� ȸ�� ����
    private float rotationSpeed = 500.0f;
    private float moveSpeed = 7.3f;
    private Transform playerTr;
    private int keyCount = 0;
    public AudioClip keySfx;
    public AudioClip Abc;
    public AudioClip Ws;
    public AudioClip Mc;
    private AudioSource audioSource;
    public GameObject textUI;
    private Text text;
    private bool hasPlayedWsSound = false;

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

        // ���콺 �Է��� ����Ͽ� ȸ���� �ε巴�� ó��
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        rotationX -= Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
        rotationX = Mathf.Clamp(rotationX, -90, 90); // ���� ȸ�� ���� ����

        // ȸ�� ����
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
            
            textUI.GetComponent<Text>().text = "���� ã�� ���� ���� : " + keyCount.ToString();
        }
        if (collision.gameObject.tag == "Abc")
        {
            audioSource.PlayOneShot(Abc, 1.0f);
        }
        if (collision.gameObject.tag == "Ws" && !hasPlayedWsSound)
        {
            audioSource.PlayOneShot(Ws, 1.0f);
            hasPlayedWsSound = true;
        }
        if (collision.gameObject.tag == "Mc")
        {
            audioSource.PlayOneShot(Mc, 1.0f);
        }
        if (collision.gameObject.tag == "DOOR" && keyCount >= 5)
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Portal")
        {
            SceneManager.LoadScene("Main");
        }
        if (collision.gameObject.tag == "navAgent")
        {
            SceneManager.LoadScene("Main");
        }
    }
}