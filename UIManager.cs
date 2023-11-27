using Godot;
using System;

public partial class UIManager : Node2D
{
	[Export]private Node2D tabMenu;
	[Export]private Node2D escMenu;
	public override void _Input(InputEvent e)
	{
		if(e.IsActionPressed("tabMenu")){
			tabMenu.Visible = true;
		}
		else if(e.IsActionReleased("tabMenu")){
			tabMenu.Visible = false;
		}
		if(e.IsActionPressed("escMenu") && escMenu.Visible == true){
			escMenu.Visible = false;
		}
		else if (e.IsActionPressed("escMenu")){
			escMenu.Visible = true;
		}

	}
}
