using Godot;
using System;

public partial class BaseCharacter : CharacterBody2D
{
    // Stats
    [Export]
    public string Name { get; set; } = "No Name";

    [Export]
    public int MaxHealth { get; set; } = 100;

    [Export]
    public int CurrentHealth { get; set; }

    [Export]
    public int CurrentMana { get; set; } = 100

    [Export]
    public int MaxMana { get; set; } = 100

    [Export]
    public int MovementSpeed { get; set; } = 300

    [Export]
    public int MovementRange { get; set; } = 3

    [Export]
    public enum CharacterState
    {
        Idle,
        Walking,
        Attacking,
        Casting,
        Hurt,
        Dead
    }

    public CharacterState CurrentState { get; protected set; } = CharacterState.Idle;

    // Animation Reference
    protected AnimatedSprite2D _animatedSprite;

    public override void _Ready()
    {
        // Init health
        CurrentHealth = MaxHealth;

        // Find the animated sprite
        _animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
    }

    protected virtual void UpdateAnimation()
    {
        if (_animatedSprite == null) return;

        switch (CurrentState)
        {
            case CharacterState.Idle:
                _animatedSprite.Play("idle");
                break;
            case CharacterState.Walking:
                _animatedSprite.Play("walk");
                break;
            case CharacterState.Hurt:
                _animatedSprite.Play("hurt");
                break;
            case CharacterState.Dead:
                _animatedSprite.Play("dead");
                break;
        }
    }

    protected virtual void Die()
    {
        CurrentState = CharacterState.Dead;
        UpdateAnimation();
        // TODO: death animation/option screen
        QueueFree();
    }

    public virtual void Heal(int healAmount)
    {
        CurrentHealth = Math.Min(CurrentHealth + healAmount, MaxHealth);
    }

    // Method to handle taking damage
    public virtual void TakeDamage(int damageAmount)
    {
        CurrentHealth -= damageAmount;
        CurrentState = CharacterState.Hurt;
        UpdateAnimation();

        if (CurrentHealth <= 0)
        {
            Die()
        }
    }
}
