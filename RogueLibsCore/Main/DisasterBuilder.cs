using System;

namespace RogueLibsCore
{
    public class DisasterBuilder
    {
        public DisasterBuilder(DisasterInfo info) => Info = info;
        public DisasterInfo Info { get; }

        public CustomName? Name { get; private set; }
        public CustomName? Description { get; private set; }
        public CustomName? Message1 { get; private set; }
        public CustomName? Message2 { get; private set; }

        public DisasterBuilder WithName(CustomNameInfo info)
        {
            Name = RogueLibs.CreateCustomName($"LevelFeeling{Info.Name}_Name", NameTypes.Interface, info);
            return this;
        }
        public DisasterBuilder WithDescription(CustomNameInfo info)
        {
            Description = RogueLibs.CreateCustomName($"LevelFeeling{Info.Name}_Desc", NameTypes.Description, info);
            return this;
        }
        public DisasterBuilder WithMessage(CustomNameInfo info)
        {
            if (Message1 is null) Message1 = RogueLibs.CreateCustomName($"LevelFeeling{Info.Name}1", NameTypes.Description, info);
            else if (Message2 is null) Message2 = RogueLibs.CreateCustomName($"LevelFeeling{Info.Name}2", NameTypes.Description, info);
            else throw new InvalidOperationException("You can't specify more than two messages for a custom disaster!");
            return this;
        }

    }
}
