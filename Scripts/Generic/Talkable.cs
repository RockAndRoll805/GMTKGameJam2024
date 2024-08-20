using Godot;
using System;

namespace GMTK24.ACT1;
public partial class Talkable : Area2D
{
	[Export] private String[] dialogue; // todo: implement dialogue box + tree
	private bool player_inside = false;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		BodyEntered += OnBodyEntered;
		BodyExited += OnBodyExited;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (player_inside && Input.IsActionJustPressed("interact")) {
			GD.Print("player interacted!");
		}
	}

	private void OnBodyEntered(Node2D other) {
		if(other is not Player) { return; }

		player_inside = true;
		
	}

	private void OnBodyExited(Node2D other) {
		if(other is not Player) { return; }

		player_inside = false;
	}
}
