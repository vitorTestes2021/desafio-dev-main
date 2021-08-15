using System;
using System.Globalization;
using api.Model;
using api.Readers.Fields.Base;

namespace api.Readers.Fields
{
    public class CNABFields : FieldsBase<CNABModel>
    {
        protected int GetType(string line)
        {
            var value = line[0].ToString();
            if (!int.TryParse(value, out int cnabType))
            {
                ThrowInvalidField("IdTransactionType", value);
            }
            return  cnabType;
        }

        protected DateTime GetDateOccurrence(string line)
        {
            var value = line.Substring(1, 8).ToString();
            if (!DateTime.TryParseExact(value, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime cnabDate))
            {
                ThrowInvalidField("Date Occurrence", value);
            }
            return cnabDate;
        }

        protected decimal GetValue(string line)
        {
            var value = line.Substring(9, 10).ToString();
            if (!decimal.TryParse(value, out decimal cnabValue))
            {
                ThrowInvalidField("Value", value);
            }
            return cnabValue / 100;
        }

        protected string GetCpf(string line)
        {
            return line.Substring(19, 11).ToString();
        }

        protected string GetCard(string line)
        {
            return line.Substring(30, 12).ToString();
        }

        protected TimeSpan GetDateOccurrenceHour(string line)
        {
            var value = line.Substring(42, 6).ToString();
            if (!TimeSpan.TryParseExact(value, "hhmmss", CultureInfo.InvariantCulture, TimeSpanStyles.None, out TimeSpan cnabHour))
            {
                ThrowInvalidField("Date Occurrence Hour", value);
            }
            return cnabHour;
        }

        protected string GetNameStoreOwner(string line)
        {
            return line.Substring(48, 14).ToString();
        }

        protected string GetNameStore(string line)
        {
            return line.Substring(62, 18).ToString();
        }
    }
}