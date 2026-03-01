using System.Collections.Generic;
using System.Linq;

namespace ST.Shared.Models
{
    public class ValidationResult
    {
        public virtual bool IsValid => Errors==null | Errors.Any();
        public Dictionary<string, List<string>> Errors { get; set; } = new Dictionary<string, List<string>>();
        public ValidationResult AddError(string propertyName, string errorMessage)
        {
            Errors = Errors ?? new Dictionary<string, List<string>>();
            if (!Errors.ContainsKey(propertyName))
                Errors[propertyName] = new List<string>();
            Errors[propertyName].Add(errorMessage); 
            return this;
        }
    }
}
