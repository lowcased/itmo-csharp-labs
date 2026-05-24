using Lab5.Domain.Accounts;
using Lab5.Domain.Operations;
using SourceKit.Generators.Builder.Annotations;

namespace Lab5.Application.Abstraction.Persistence.Queries;

[GenerateBuilder]
public sealed partial record OperationQuery(OperationId[] OperationIds, AccountId[] AccountIds);