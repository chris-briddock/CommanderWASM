using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Commander.WASM.Shared
{
    public interface IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
    }
}

