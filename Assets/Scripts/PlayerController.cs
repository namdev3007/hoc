﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class PlayerController : MonoBehaviour
{
    public CharacterDatabase characterDB;
    public SpriteRenderer artworkSprite;

    private int selectedOption;


    public float moveForce = 5;
    public float JumpHeight;
    public Vector2 boxSize;
    public float castDistance;
    public LayerMask groundLayer;

    Rigidbody2D rb2d;
    float dirX;

    AudioManager audioManager;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();

        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        if(!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption = 0;
        }
        else
        {
            Load();
        }
        UpdateCharacter(selectedOption);
    }
    private void Update()
    {
        dirX = Input.GetAxis("Horizontal");

        rb2d.velocity = new Vector2(dirX * moveForce, rb2d.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space)&& IsGrounded())
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, JumpHeight *3);
            audioManager.PlaySFX(audioManager.jump);
        }
    }
    public bool IsGrounded()
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer))
        {
            return true;
        }
        else
        { return false; }
    }
    private void UpdateCharacter(int selectedOption)
    {
        Character character = characterDB.GetCharacter(selectedOption);
        artworkSprite.sprite = character.characterSprite;
    }
    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }

}
