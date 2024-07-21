namespace Chill011;

public class Body : BodyPart
{
    public Dictionary<BodySlots, Vector2> bodyJoints;
    public Dictionary<BodySlots, BodyPart> bodyParts = [];

    public Body(Texture2D texture) : base(texture)
    {
        Origin = Vector2.Zero;
    }

    public void AddBodyPart(BodySlots _bodyParts, BodyPart _bodyPart)
    {
        bodyParts.Add(_bodyParts, _bodyPart);
        _bodyPart.Position = Position + bodyJoints[_bodyParts];
        //if (_bodyParts != BodyParts.Eye) _bodyPart.color = color;
    }

    public override void Draw()
    {
        bodyParts[BodySlots.LeftLeg].Draw();
        bodyParts[BodySlots.RightLeg].Draw();
        bodyParts[BodySlots.LeftArm].Draw();
        bodyParts[BodySlots.RightArm].Draw();

        base.Draw();

        bodyParts[BodySlots.Eye].Draw();
        bodyParts[BodySlots.Mouth].Draw();
    }
}
