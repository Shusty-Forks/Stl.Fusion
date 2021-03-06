using System;
using System.Threading;
using System.Threading.Tasks;
using Stl.CommandR.Configuration;
using Stl.Fusion.Extensions.Commands;
using Stl.Text;

namespace Stl.Fusion.Extensions
{
    public interface IKeyValueStore
    {
        public static ListFormat ListFormat { get; } = ListFormat.SlashSeparated;
        public static char Delimiter => ListFormat.Delimiter;

        [CommandHandler]
        Task SetAsync(SetCommand command, CancellationToken cancellationToken = default);
        [CommandHandler]
        Task SetManyAsync(SetManyCommand command, CancellationToken cancellationToken = default);
        [CommandHandler]
        Task RemoveAsync(RemoveCommand command, CancellationToken cancellationToken = default);
        [CommandHandler]
        Task RemoveManyAsync(RemoveManyCommand command, CancellationToken cancellationToken = default);

        [ComputeMethod]
        Task<string?> TryGetAsync(string key, CancellationToken cancellationToken = default);
        [ComputeMethod]
        Task<int> CountByPrefixAsync(string prefix, CancellationToken cancellationToken = default);
        [ComputeMethod]
        Task<string[]> ListKeysByPrefixAsync(
            string prefix,
            PageRef<string> pageRef,
            SortDirection sortDirection = SortDirection.Ascending,
            CancellationToken cancellationToken = default);
    }

    public interface IKeyValueStore<TContext> : IKeyValueStore { }
}
