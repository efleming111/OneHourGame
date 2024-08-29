using Godot;

public partial class CameraController : Node3D
{
	[Export]
	private Node3D target;

	[Export]
	private float sensitivity = 1.0f;

	private Vector2 mouseRelative = Vector2.Zero;
	private Vector3 cameraRotation = Vector3.Zero;

	private const float DEGREE_TO_RADIANS = .0174533F;

	public override void _Ready()
	{
		Input.MouseMode = Input.MouseModeEnum.Captured;
	}

	public override void _Process(double delta)
	{
		cameraRotation.Y += -mouseRelative.X * sensitivity * DEGREE_TO_RADIANS;
		cameraRotation.X += mouseRelative.Y * sensitivity * DEGREE_TO_RADIANS;

		Rotation = cameraRotation;
        GlobalPosition = target.GlobalPosition;

		mouseRelative = Vector2.Zero;
    }

    public override void _Input(InputEvent @event)
    {
        if(@event is InputEventMouseMotion mouseMotion)
		{
			mouseRelative = mouseMotion.Relative;
		}
    }
}
