using System;

namespace api.Model
{
    public class CNABModel
    {
        public int Id { get; set; }
        public int IdTransactionType { get; set; }
        public decimal Value { get; set; }
        public string ValueText
        {
            get
            {
                return Value.ToString("C");
            }
        }
        public string Cpf { get; set; }
        public string Card { get; set; }
        public string NameStore { get; set; }
        public string NameStoreOwner { get; set; }
        public DateTime? DateOccurrence { get; set; } = null;
        public string DateOccurrenceText
        {
            get
            {
                return DateOccurrence?.ToString("dd/MM/yyyy") ?? string.Empty;
            }
        }
        public TimeSpan? DateOccurrenceHour { get; set; } = null;
        public string DateOccurrenceHourText
        {
            get
            {
                return DateOccurrenceHour?.ToString(@"hh\:mm\:ss") ?? string.Empty;
            }
        }
    }
}