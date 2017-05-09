using FileHelpers;

namespace TechnicalAssessmentExtension.Helpers
{
    [DelimitedRecord(","), IgnoreFirst(1)]
    public class Client
    {
        public Client()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            AddressString = string.Empty;
            PhoneNumber = string.Empty;
            //FullName = string.Empty;
        }

        [FieldOrder(1)]
        public string FirstName { get; set; }

        [FieldOrder(2)]
        public string LastName { get; set; }

        [FieldOrder(3)]
        public string AddressString { get; set; }

        [FieldOrder(4)]
        public string PhoneNumber { get; set; }

        public Address Address => new Address(AddressString);
    }
}