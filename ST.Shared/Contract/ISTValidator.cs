using ST.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ST.Shared.Contract
{
    public interface ISTValidator<T>
    {
        ValidationResult Validate(T value);
        ValidationResult ValidateAsync(T value, CancellationToken cancellationToken = default);
    }
}
