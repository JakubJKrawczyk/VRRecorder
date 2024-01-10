namespace VRParser.Entities
{
    [Serializable]
    public class MatriceModel
    {
        public List<Record> RecordsSequence { get; set; } = new();
    }
}