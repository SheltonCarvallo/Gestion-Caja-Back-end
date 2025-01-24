namespace GestionDeCajas.Utilities
{
    public record SaveConfirmation
    {
        public bool CouldBeSaved{ get; set; }
        public string? Message { get; set; }
    }
}
