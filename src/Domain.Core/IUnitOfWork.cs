﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core
{
    /// <summary>
    /// Contrato para 'Unit of Work Pattern'
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Confirma los cambios realizados en un contenedor.
        /// </summary>
        /// <returns>Número de registros confirmados.</returns>
        int Commit();

        /// <summary>
        /// Asíncronamente confirma los cambios realizados en un contenedor.
        /// </summary>
        /// <returns>Número de registros confirmados.</returns>
        Task<int> CommitAsync();

        /// <summary>
        /// Deshace los cambios realizados en un contenedor.
        /// </summary>
        void RollbackChanges();
    }
}
