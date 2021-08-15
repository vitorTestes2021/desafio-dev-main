using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using api.Model;
using api.Readers.Fields;

namespace api.Readers
{
    public class CNABReader : CNABFields
    {
        private int _lineMaxLength;

        public CNABReader(int lineMaxLength)
        {
            _lineMaxLength = lineMaxLength;
        }

        public async Task<List<CNABModel>> ConvertFileToCNABList(Stream text)
        {
            using(var reader = new StreamReader(text))
            {
                string line;
                while(reader.Peek() >= 0)
                {
                    line = await reader.ReadLineAsync();
                    if (isLineValid(line))
                    {
                        List.Add(GenerateCNAB(line));
                    }
                    else
                    {
                        throw new System.Exception($"Error at line: {GetListLength()}, invalid size.");
                    }
                }
            }
            return List;
        }

        private CNABModel GenerateCNAB(string line)
        {
            return new CNABModel()
            {
                IdTransactionType = GetType(line),
                DateOccurrence = GetDateOccurrence(line),
                Value = GetValue(line),
                Cpf = GetCpf(line),
                Card = GetCard(line),
                DateOccurrenceHour = GetDateOccurrenceHour(line),
                NameStoreOwner = GetNameStoreOwner(line),
                NameStore = GetNameStore(line)
            };
        }

        private bool isLineValid(string line)
        {
            return line.Length == _lineMaxLength;
        }
    }
}