using Godot;
using System;

public partial class PlayerShip : CharacterBody2D
{
	[Export] private int movespeed = 250;

	private AnimatedSprite2D sprite;
	private CollisionShape2D collider;

	// GETTERS AND SETTERS
	public int Movespeed { get => movespeed; set => movespeed = value; }

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// initialize sprite and collider
		sprite = (AnimatedSprite2D) GetNode("AnimatedSprite2D");
		collider = (CollisionShape2D) GetNode("CollisionShape2D");	
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		HandleMove();

		MoveAndSlide();
	}

	// Handles all movement related actions
	private void HandleMove() {
		
		// Godot.Vector2 velocity = Velocity;
		Godot.Vector2 input_dir = new(Input.GetAxis("ui_left", "ui_right"), Input.GetAxis("ui_up", "ui_down"));
		// GD.Print(input_dir); // DEBUG 

		// handle ship movement
		Godot.Vector2 velocity = input_dir * movespeed;
		if(input_dir.X != 0) {
			sprite.FlipH = input_dir.X < 0;
		}

		if(input_dir.Y != 0){
			sprite.FlipV = input_dir.Y < 0;
		}
		
		Velocity = velocity;

	}
}
