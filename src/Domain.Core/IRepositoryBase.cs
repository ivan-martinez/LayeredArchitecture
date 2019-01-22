using Domain.Core.Specification;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Domain.Core
{
    /// <summary>
    /// Interfaz base para implementar un "Repository Pattern".
    /// </summary>
    /// <typeparam name="TEntity">Tipo de entidad para este repositorio.</typeparam>
    public interface IRepositoryBase
    {
        /// <summary>
        /// Obtiene el 'unit of work' para este repositorio.
        /// </summary>
        DbContext UnitOfWork { get; }

        /// <summary>
        /// Agrega un item al repositorio.
        /// </summary>
        /// <typeparam name="TEntity">Tipo de entidad para este repositorio.</typeparam>
        /// <param name="item">Item que se va agregar al repositorio.</param>
        void Add<TEntity>(TEntity item) where TEntity : class, new();

        /// <summary>
        /// Elimina item.
        /// </summary>
        /// <typeparam name="TEntity">Tipo de entidad para este repositorio.</typeparam>
        /// <param name="item">Item que se va eliminar del repositorio.</param>
        void Remove<TEntity>(TEntity item) where TEntity : class, new();

        /// <summary>
        /// Modifica item del repositorio.
        /// </summary>
        /// <typeparam name="TEntity">Tipo de entidad para este repositorio.</typeparam>
        /// <param name="item">Item que se va modificar.</param>
        void Modify<TEntity>(TEntity item) where TEntity : class, new();

        /// <summary>
        /// Modifica una colección de items del repositorio.
        /// </summary>
        /// <typeparam name="TEntity">Tipo de entidad para este repositorio.</typeparam>
        /// <param name="items">Colección de items que se modificaran.</param>
        int Modify<TEntity>(ICollection<TEntity> items) where TEntity : class, new();

        /// <summary>
        /// Adjunta el item dentro del "ObjectStateManager".
        /// </summary>
        /// <typeparam name="TEntity">Tipo de entidad para este repositorio.</typeparam>
        /// <param name="item">El item.</param>
        void Attach<TEntity>(TEntity item) where TEntity : class, new();

        /// <summary>
        /// Obtiene elementos del tipo TEntity del repositorio.
        /// </summary>
        /// <typeparam name="TEntity">Tipo de entidad para este repositorio.</typeparam>
        /// <returns>Lista de elementos.</returns>
        IEnumerable<TEntity> GetAll<TEntity>() where TEntity : class, new();

        /// <summary>
        /// Obtiene un elemento del tipo TEntity del repositorio mediante su clave primaria.
        /// </summary>
        /// <typeparam name="TEntity">Tipo de entidad para este repositorio.</typeparam>
        /// <returns>Lista de elementos.</returns>
        TEntity GetById<TEntity>(params object[] keys) where TEntity : class, new();

        /// <summary>
        /// Obtiene los elementos del tipo TEntity del repositorio que cumplen la expresión de búsqueda.
        /// </summary>
        /// <typeparam name="TEntity">Tipo de entidad para este repositorio.</typeparam>
        /// <returns>Lista de elementos.</returns>
        IEnumerable<TEntity> FindBy<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class, new();

        /// <summary>
        /// Obtiene elementos del tipo TEntity del repositorio que cumplan una especificación.
        /// </summary>
        /// <typeparam name="TEntity">Tipo de entidad para este repositorio.</typeparam>
        /// <param name="specification">Especificación que se debe cumplir.</param>
        /// <returns></returns>
        IEnumerable<TEntity> GetBySpecification<TEntity>(ISpecification<TEntity> specification) where TEntity : class, new();

        /// <summary>
        /// Obtiene elementos del tipo TEntity del repositorio páginados.
        /// </summary>
        /// <typeparam name="TEntity">Tipo de entidad para este repositorio.</typeparam>
        /// <typeparam name="S"></typeparam>
        /// <param name="pageIndex">Número de página.</param>
        /// <param name="pageCount">Cantidad de elementos por página.</param>
        /// <param name="orderByExpression">Especificación de orden.</param>
        /// <param name="ascending">Es true si se devuelven elementos ordenados ascendentemente.</param>
        /// <returns></returns>
        IEnumerable<TEntity> GetPagedElements<TEntity, S>(int pageIndex, int pageCount, Expression<Func<TEntity, S>> orderByExpression, bool ascending) where TEntity : class, new();
    }
}
