using System.Collections.Generic;

namespace api.Readers.Fields.Base
{
    public abstract class FieldsBase<T> where T : class
    {
        protected List<T> List;

        public FieldsBase()
        {
            List = new List<T>();
        }

        protected int GetListLength()
        {
            return List.Count + 1;
        }

        protected void ThrowInvalidField(string fieldName, string value)
        {
            throw new System.Exception($"Error at line: {GetListLength()}, invalid field: ({fieldName}) - value: ({value}).");
        }
    }
}