namespace ModelLayer.Models
{
    public class AttentionModel
    {
        public int AttentionId { get; set; }
        public int TurnId { get; set; }
        public int ClientId { get; set; }
        public string AttentionTypeId { get; set; } = string.Empty;
        public int AttentionStatusId { get; set; }
        public TurnModel Turn { get; set; } = null!;
        public ClientModel Client { get; set; } = null!;
        public AttentionTypeModel AttentionType { get; set; } =  null!;
        public AttentionStatusModel AttentionStatus { get; set; } = null!;
    }
}
        