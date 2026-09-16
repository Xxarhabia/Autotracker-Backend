using Autotracker.Domain.Entities;

namespace Autotracker.Domain.Builders
{
    public class DriverBuilder
    {
        private string _name = string.Empty;
        private string _document = string.Empty;
        private string _phone = string.Empty;

        public DriverBuilder WithName(string name) 
        {
            _name = name;
            return this;
        }

        public DriverBuilder WithDocument(string document) 
        {
            _document = document;
            return this;
        }

        public DriverBuilder WithPhone(string phone) 
        {
            _phone = phone;
            return this;
        }

        public Driver build()
        {
            return new Driver(
                _name,
                _document,
                _phone
            );
        }
    }
}
