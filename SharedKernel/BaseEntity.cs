using System;
namespace ProgamObiektoweZadanieDomowe.SharedKernel
{
    public abstract class BaseEntity
    {
        public virtual int Id { get; set; }
        private string _name;
        public virtual string Name {
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException(nameof(value), "Name is can't be null.");
                _name = value;
            }
            get { return _name; }
        }
    }
}
