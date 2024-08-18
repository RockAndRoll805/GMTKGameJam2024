using Godot;
using System;

public partial class CameraController : Camera2D
{

	[Export] private Node2D target;
	[Export] private int tolerance_dist = 5;
	[Export] private Vector2 camera_zoom = new(1, 1);

	public Vector2 CameraZoom { get => camera_zoom; set => camera_zoom = value; }

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.Zoom = camera_zoom;
		this.Position = target.Position;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		// smooth camera
		Vector2 dist_to_target = target.Position - this.Position;
		if(dist_to_target.Length() > tolerance_dist) {
			this.Position += dist_to_target.Normalized() * dist_to_target.Length()*0.1f;
		}
	}

	public void SetCameraPos(Vector2 pos) { this.Position = pos; }
}
