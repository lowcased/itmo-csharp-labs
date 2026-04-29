using Lab5.Domain.Accounts;
using Lab5.Domain.ValueObjects;
using SourceKit.Generators.Builder.Annotations;

namespace Lab5.Application.Abstraction.Persistence.Queries;

[GenerateBuilder]
public sealed partial record AccountQuery(AccountId[] Ids, AccountNumber[] Numbers);