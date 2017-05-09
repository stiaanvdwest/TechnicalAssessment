using System;
using System.Linq;

namespace TechnicalAssessmentExtension.Helpers
{
    public class Address
    {
        public Address()
        {
            Number = 0;
            Street = string.Empty;
        }

        public Address(string address)
        {
            int numIndex = int.MinValue;
            string[] tokens = address.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var addr = this;
            for (int i = 0; i < tokens.Length; i++)
            {
                int num;
                if (!addr.Number.HasValue && int.TryParse(tokens[i], out num))
                {
                    addr.Number = num;
                    numIndex = i;
                }
            }
            addr.Street = addr.Number.HasValue ? string.Join(" ", tokens.Where((s, i) => i != numIndex).ToArray()) : address;
        }

        public int? Number { get; set; }
        public string Street { get; set; }

        public string FullAddress => $"{Number} {Street}";
    }
}
