namespace Bz.F8t.Administration.Application.Common;

public sealed record ValidationError(
    string PropertyName,
    string ErrorMessage) { }
