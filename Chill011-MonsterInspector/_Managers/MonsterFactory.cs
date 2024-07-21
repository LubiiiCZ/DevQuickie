namespace Chill011;

public enum BodyParts
{
    Body,
    Leg,
    Eye,
    Arm,
    Mouth,
}

public enum BodySlots
{
    Body,
    LeftLeg,
    RightLeg,
    Eye,
    LeftArm,
    RightArm,
    Mouth,
}

public static class MonsterFactory
{
    private static readonly Dictionary<BodyParts, int> _partCount = new()
    {
        { BodyParts.Body, 6 },
        { BodyParts.Leg, 5 },
        { BodyParts.Arm, 5 },
        { BodyParts.Eye, 17 },
        { BodyParts.Mouth, 14 },
    };
    private static readonly Dictionary<BodyParts, string> _partPath = new()
    {
        { BodyParts.Body, "body/body" },
        { BodyParts.Leg, "leg/leg" },
        { BodyParts.Arm, "arm/arm" },
        { BodyParts.Eye, "eye/eye" },
        { BodyParts.Mouth, "mouth/mouth" },
    };
    private static readonly Dictionary<BodyParts, Dictionary<int, Texture2D>> _textures = [];
    private static readonly Dictionary<int, Dictionary<BodySlots, Vector2>> _bodyJoints = [];
    private static readonly Dictionary<int, Vector2> _legJoints = [];
    private static readonly Dictionary<int, Vector2> _armJoints = [];
    private static readonly Random random = new();

    public static void Load()
    {
        foreach (var part in (BodyParts[]) Enum.GetValues(typeof(BodyParts)))
        {
            Dictionary<int, Texture2D> temp = [];
            for (int i = 0; i < _partCount[part]; i++)
                temp.Add(i, Globals.Content.Load<Texture2D>($"{_partPath[part]}{i}"));
            _textures.Add(part, temp);
        }

        _bodyJoints.Add(0, new() {
            { BodySlots.LeftLeg, new(20, 150) },
            { BodySlots.RightLeg, new(145, 150) },
            { BodySlots.LeftArm, new(10, 80) },
            { BodySlots.RightArm, new(155, 80) },
            { BodySlots.Eye, new(82, 50) },
            { BodySlots.Mouth, new(82, 105) },
        });
        _bodyJoints.Add(1, new() {
            { BodySlots.LeftLeg, new(60, 160) },
            { BodySlots.RightLeg, new(132, 160) },
            { BodySlots.LeftArm, new(20, 80) },
            { BodySlots.RightArm, new(172, 80) },
            { BodySlots.Eye, new(96, 75) },
            { BodySlots.Mouth, new(96, 130) },
        });
        _bodyJoints.Add(2, new() {
            { BodySlots.LeftLeg, new(40, 160) },
            { BodySlots.RightLeg, new(101, 160) },
            { BodySlots.LeftArm, new(15, 90) },
            { BodySlots.RightArm, new(126, 90) },
            { BodySlots.Eye, new(71, 60) },
            { BodySlots.Mouth, new(71, 115) },
        });
        _bodyJoints.Add(3, new() {
            { BodySlots.LeftLeg, new(50, 150) },
            { BodySlots.RightLeg, new(124, 150) },
            { BodySlots.LeftArm, new(20, 90) },
            { BodySlots.RightArm, new(154, 90) },
            { BodySlots.Eye, new(87, 75) },
            { BodySlots.Mouth, new(87, 130) },
        });
        _bodyJoints.Add(4, new() {
            { BodySlots.LeftLeg, new(40, 230) },
            { BodySlots.RightLeg, new(92, 230)  },
            { BodySlots.LeftArm, new(20, 120) },
            { BodySlots.RightArm, new(112, 120) },
            { BodySlots.Eye, new(66, 80) },
            { BodySlots.Mouth, new(66, 135) },
        });
        _bodyJoints.Add(5, new() {
            { BodySlots.LeftLeg, new(50, 210) },
            { BodySlots.RightLeg, new(120, 210) },
            { BodySlots.LeftArm, new(30, 110) },
            { BodySlots.RightArm, new(140, 110) },
            { BodySlots.Eye, new(85, 90) },
            { BodySlots.Mouth, new(85, 145) },
        });

        _legJoints.Add(0, new(25, 25));
        _legJoints.Add(1, new(16, 16));
        _legJoints.Add(2, new(22, 22));
        _legJoints.Add(3, new(22, 22));
        _legJoints.Add(4, new(26, 26));

        _armJoints.Add(0, new(25, 25));
        _armJoints.Add(1, new(18, 18));
        _armJoints.Add(2, new(30, 30));
        _armJoints.Add(3, new(30, 30));
        _armJoints.Add(4, new(25, 20));
    }

    private static Color GetRandomColor()
    {
        return random.Next(4) switch
        {
            0 => new(250, 120, 130),
            1 => new(100, 180, 110),
            2 => new(70, 140, 240),
            3 => new(250, 230, 110),
            _ => Color.White,
        };
    }

    public static Body GetRandomMonster()
    {
        var randomBodyId = random.Next(_partCount[BodyParts.Body]);

        Body body = new(_textures[BodyParts.Body][randomBodyId])
        {
            bodyJoints = _bodyJoints[randomBodyId],
            Position = new(800, 450),
            color = GetRandomColor(),
            partId = randomBodyId,
        };

        var leftLeg = GetRandomPart(BodyParts.Leg);
        leftLeg.flip = SpriteEffects.FlipHorizontally;
        leftLeg.Origin = new(leftLeg.Texture.Width - _legJoints[leftLeg.partId].X, _legJoints[leftLeg.partId].Y);
        body.AddBodyPart(BodySlots.LeftLeg, leftLeg);

        var rightLeg = GetRandomPart(BodyParts.Leg, leftLeg.partId);
        rightLeg.Origin = _legJoints[rightLeg.partId];
        body.AddBodyPart(BodySlots.RightLeg, rightLeg);

        var leftArm = GetRandomPart(BodyParts.Arm);
        leftArm.flip = SpriteEffects.FlipHorizontally;
        leftArm.Origin = new(leftArm.Texture.Width - _armJoints[leftArm.partId].X, _armJoints[leftArm.partId].Y);
        leftArm.Rotation = 0.5f;
        body.AddBodyPart(BodySlots.LeftArm, leftArm);

        var rightArm = GetRandomPart(BodyParts.Arm, leftArm.partId);
        rightArm.Origin = _armJoints[rightArm.partId];
        rightArm.Rotation = -0.5f;
        body.AddBodyPart(BodySlots.RightArm, rightArm);

        var eye = GetRandomPart(BodyParts.Eye);
        eye.color = Color.White;
        body.AddBodyPart(BodySlots.Eye, eye);

        var mouth = GetRandomPart(BodyParts.Mouth);
        mouth.color = Color.White;
        body.AddBodyPart(BodySlots.Mouth, mouth);

        return body;
    }

    private static BodyPart GetRandomPart(BodyParts part, int idOverride = -1)
    {
        var id = idOverride < 0 ? random.Next(_partCount[part]) : idOverride;
        var texture = _textures[part][id];

        BodyPart bodyPart = new(texture)
        {
            partId = id,
            color = GetRandomColor(),
            Origin = new(texture.Width / 2, texture.Height / 2),
        };

        return bodyPart;
    }
}
