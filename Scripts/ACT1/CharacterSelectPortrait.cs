using Godot;
using System;

public partial class CharacterSelectPortrait : Area2D
{

	[Export] private string next_scene = ""; // the next scene to be loaded

	// Visual Vars
	[Export] private int alpha_speed = 4; // the speed at which the alpha value modulates
	private float curr_alpha = 0;

	// Booleans
	private bool is_mouse_inside = false;
	
	// Nodes
	private Label character_name;
	private TextureRect character_portrait;
	private CollisionShape2D collider;
	private Control character_ui;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		collider = GetNode<CollisionShape2D>("CollisionShape2D");
		character_ui = GetNode<Control>("UI");
		
		character_name = character_ui.GetNode<Label>("Character Name");
		character_portrait = character_ui.GetNode<TextureRect>("Character Portrait");

		character_ui.MouseFilter = Control.MouseFilterEnum.Ignore; // disable mouse filter so that mouse interactions work

		// initialize signal functions
		MouseEntered += OnMouseEntered;
		MouseExited += OnMouseExited;
	}
	
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{	
		if(is_mouse_inside) {
			// GD.Print("mouse inside"); // DEBUG
			// "flash" character name text while mouse is inside the text box
			curr_alpha += alpha_speed*(float)delta;
			character_name.Modulate = new Godot.Color(character_name.Modulate.R, character_name.Modulate.G, character_name.Modulate.B, (1+(float)Math.Sin(curr_alpha))/2);

			if(Input.IsMouseButtonPressed(MouseButton.Left)) {
				GD.Print("character selected");
				
				// Load next scene
				// GetTree().ChangeSceneToFile(next_scene); // UNCOMMENT THIS ONCE THE NEXT SCENE IS CREATED
			}
		}
		else {
			// reset character name name
			character_name.Modulate = new Godot.Color(character_name.Modulate.R, character_name.Modulate.G, character_name.Modulate.B, 1);
			curr_alpha = 1;
		}
	}

	private void OnMouseEntered() {
		is_mouse_inside = true;
	}

	private void OnMouseExited() {
		is_mouse_inside = false;
	}
}
