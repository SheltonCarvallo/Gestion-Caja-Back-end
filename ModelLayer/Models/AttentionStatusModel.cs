
namespace ModelLayer.Models
{
    public class AttentionStatusModel
    {

        public int StatusId { get; set; }
        public string Descrription { get; set; } = string.Empty;
        public ICollection<AttentionModel> Attentions { get; set; } = new List<AttentionModel>();

    }
}
