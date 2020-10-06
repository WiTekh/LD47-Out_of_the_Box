using System.Collections;
using System.Collections.Generic;
using System.IO;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    private Rigidbody2D m_rb2D;

    private int m_sceneIndex;

    private Animator m_animator;
    private float m_lastDir;
    int m_o = 0;

    private bool m_isDed;

    private Sprite m_sprite;
    public float Speed;
    public float JumpForce;

    private readonly float m_fallMultiplier = 2.5f;
    private readonly float m_lowJumpMultiplier = 2f;

    private bool m_isGrounded = false;
    public LayerMask LayersToReloadJump;

    private float m_lastTimeGrounded;

    void Start()
    {
        m_sceneIndex = SceneManager.GetActiveScene().buildIndex;
        Color l_oo = transform.GetChild(0).GetChild(0).GetComponent<RawImage>().color;
        l_oo = new Color(l_oo.r, l_oo.g, l_oo.b, 0);
        transform.GetChild(0).GetChild(0).GetComponent<RawImage>().color = l_oo;
        m_isDed = false;
        m_lastDir = 0;
        m_sprite = Resources.Load(Path.Combine("Sprites", "jumpFrame")) as Sprite;
        m_animator = GetComponent<Animator>();
        m_rb2D = GetComponent<Rigidbody2D>();

        for (int l_i = 0; l_i < 4; l_i++)
        {
            if (l_i < PlayerPrefs.GetInt("Rewinds")) 
            {
                GameObject.Find($"R{l_i+1}").SetActive(true); 
            }
            else
            {
                GameObject.Find($"R{l_i+1}").SetActive(false); 
            }
        }
    }

    void Update()
    {
        if (!m_isDed)
        {
            Move();
            Jump();
        }
    }

    void FixedUpdate()
    {
        VelocityComputing();
    }

    void Move() {
        float l_x = 0;

        if (Input.GetKey(KeyCode.A))
        {
            l_x -= 1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            l_x += 1;
        }

        if (l_x != 0)
        {
            m_o = 0;
            m_animator.SetBool("isRunning", true);
            transform.rotation = Quaternion.Euler(new Vector3(0, l_x == -1 ? 180 : 0, 0));
        }
        else
        {
            if (m_o==0)
                transform.Rotate(new Vector3(0,180, 0));
            m_animator.SetBool("isRunning", false);
            m_o = 1;
        }
        
        float l_moveBy = l_x * Speed;

        m_rb2D.velocity = new Vector2(l_moveBy, m_rb2D.velocity.y);
    }

    void Jump() 
    {
        if (Input.GetKeyDown(KeyCode.Space) && m_isGrounded)
        {
            GetComponent<AudioSource>().Play();

            m_rb2D.velocity = new Vector2(m_rb2D.velocity.x, JumpForce);
            m_isGrounded = false;
        }
    }

    void VelocityComputing() 
    {
        if (m_rb2D.velocity.y < 0) 
        {
            m_rb2D.velocity += Vector2.up * Physics2D.gravity * (m_fallMultiplier - 1) * Time.deltaTime;
        } 
        else if (m_rb2D.velocity.y > 0 && !Input.GetKey(KeyCode.Space)) 
        {
            m_rb2D.velocity += Vector2.up * Physics2D.gravity * (m_lowJumpMultiplier - 1) * Time.deltaTime;
        }   
    }

    void OnCollisionEnter2D(Collision2D p_col)
    {
        if (p_col.collider.CompareTag("Ground") || p_col.collider.CompareTag("Box"))
        {
            m_isGrounded = true;
        }
    }

    public void Death()
    {
        transform.GetChild(0).GetChild(0).GetComponent<turnToDark>().IsDed = true;
        Destroy(GetComponent<Animator>());
        
        m_isDed = true;
        StartCoroutine(DelayedLoad());
        m_rb2D.AddForce(new Vector2(-2, 7));
        transform.DORotate(new Vector3(0, 0 , -90), 0.2f);
    }

    IEnumerator DelayedLoad()
    {
        yield return new WaitForSecondsRealtime(3f);
        SceneManager.LoadScene(m_sceneIndex);
    }
    
}
