namespace Vehicle.Entities
{
    public class Detail
    {
        public int Id { get; set; }
        public int ProcedureId { get; set; }
        public int HistoryId { get; set; }
        public int LaborPrice { get; set; }
        public int SparePartsPrice { get; set; }
        public int TotalPrice => LaborPrice + SparePartsPrice;
        public string Remarks { get; set; }
        public virtual History History { get; set; }
        public virtual Procedure Procedure { get; set; }
    }
}
