using System;
using Commander.WASM.Shared;

namespace Commander.WASM.Server.Data
{
    public interface ICommandRepo
    {
        bool SaveChanges();
        IEnumerable<Command> ReadAll();
        void Create(Command command);
        Command Read(Guid Id);
        void Update(Command command);
        void Delete(Guid Id);

        Task<int> SaveChangesAsync();
        Task<IList<Command>> ReadAllAsync();
        Task<Command> ReadAsync(Guid Id);
    }
}

