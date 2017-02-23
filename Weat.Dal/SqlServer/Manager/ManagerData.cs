using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Design.PluralizationServices;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Weat.Technical;
using LinqKit;
using Weat.Dal.SqlServer.DataModel;
using System.Configuration;
using Microsoft.Practices.Unity;
using Weat.Entities.DataModel;

namespace Weak.Dal.SqlServer.Manager
{
    public class ManagerData : IManagerData
    {
        private WeatEntities context;
        private readonly PluralizationService pluralizer;

        public ManagerData(WeatEntities context)
        {
            string message = "Error";
            if (context == null)
                throw new ArgumentNullException(message);
            try
            {

                context.Configuration.AutoDetectChangesEnabled = false;
                var objectContext = (this.context as IObjectContextAdapter).ObjectContext;
                objectContext.CommandTimeout = Int32.Parse(ConfigHelper.GetValueInSectionAppSettings("SqlCommandTimeout"));
                pluralizer = PluralizationService.CreateService(CultureInfo.GetCultureInfo("en"));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
        }
        [InjectionConstructor]
        public  ManagerData()
        {
            context = new WeatEntities(ConfigurationManager.AppSettings["CONNEXION"]);
            var objectContext = (context as IObjectContextAdapter).ObjectContext;
        }
        /// <summary>
        /// Initialise une nouvelle instance de ManagerImpl
        /// </summary>
        /// 

        /// <summary>
        /// Retourne une instance d' IQueryable liée à une classe de type TEntity
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public IQueryable<TEntity> GetQuery<TEntity>() where TEntity : class
        {
            return context.Set<TEntity>().AsExpandable();
        }

        public IEnumerable<TEntity> WhereAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Exécute une requête passée en paramètre.
        /// </summary>       
        /// <param name="query"></param>
        /// <returns></returns>
        /// <remarks>Cette méthode doit être utilsée uniquement pour les tests unitaires</remarks>
        public int ExecuteQuery(List<string> queryList)
        {
            int result = 0;

            if (queryList == null || queryList.Count == 0)
            {
                throw new ArgumentNullException("Error");
            }

            try
            {
                foreach (string query in queryList)
                {
                    result = context.Database.ExecuteSqlCommand(query);
                }

                return result;
            }
            catch (ArgumentNullException argEx)
            {


                throw new ArgumentNullException(argEx.Message);
            }
            catch (SqlException sqlEx)
            {


                throw sqlEx;
            }
            catch (System.Exception ex)
            {


                throw new Exception(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }

        }

        /// <summary>       
        /// Exécute une requête passée en paramètre.       
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        //public IEnumerable<TEntity> ExecuteQuery<TEntity>(string query, ObjectParameter[] parameters) where TEntity : class
        //{
        //    return null;
        //}

        /// <summary>
        /// Retourne toutes les entrées de type TEntity
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public IEnumerable<TEntity> GetAll<TEntity>() where TEntity : class
        {
            return GetQuery<TEntity>().AsEnumerable();
        }
        /// <summary>
        /// Retourne les entrées de la table TEntity selon les critères passés en paramètres 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> Find<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            string message = "Error";
            if (predicate == null)
                throw new ArgumentNullException(message);
            try
            {
                return GetQuery<TEntity>().AsExpandable().Where(predicate).AsEnumerable();
            }
            catch (ArgumentNullException argEx)
            {


                throw new ArgumentNullException(argEx.Message);
            }
            catch (SqlException sqlEx)
            {


                throw sqlEx;
            }
            catch (System.Exception ex)
            {


                throw new Exception(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }

        /// <summary>
        /// Retourne les entrées de la table TEntity selon les critères passés en paramètres 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IQueryable<TEntity> FindQueryable<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            string message = "Error";
            if (predicate == null)
                throw new ArgumentNullException(message);
            try
            {
                return GetQuery<TEntity>().AsExpandable().Where(predicate);
            }
            catch (ArgumentNullException argEx)
            {


                throw new ArgumentNullException(argEx.Message);
            }
            catch (SqlException sqlEx)
            {
                throw sqlEx;
            }
            catch (System.Exception ex)
            {


                throw new Exception(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }

        /// <summary>
        /// Retourne les entrées de la table TEntity selon les critères passés en paramètres 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> Where<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            string message = "Error";
            if (predicate == null)
                throw new ArgumentNullException(message);
            try
            {
                return GetQuery<TEntity>().Where(predicate).AsEnumerable();
            }
            catch (ArgumentNullException argEx)
            {


                throw new ArgumentNullException(argEx.Message);
            }
            catch (SqlException sqlEx)
            {


                throw sqlEx;
            }
            catch (System.Exception ex)
            {

                
                throw new Exception(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }

        /// <summary>
        /// Retourne une entrée de la table TEntity selon les critères passés en paramètres 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public TEntity Single<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            string message = "Error";
            if (predicate == null)
                throw new ArgumentNullException(message);
            try
            {
                return GetQuery<TEntity>().SingleOrDefault<TEntity>(predicate);
            }
            catch (ArgumentNullException argEx)
            {


                throw new ArgumentNullException(argEx.Message);
            }
            catch (SqlException sqlEx)
            {


                throw sqlEx;
            }
            catch (System.Exception ex)
            {


                throw new Exception(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }

        public async Task<TEntity> SingleAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            try
            {
                return await context.Set<TEntity>().SingleAsync(predicate);
            }
            catch (ArgumentNullException argEx)
            {


                throw new ArgumentNullException(argEx.Message);
            }
            catch (SqlException sqlEx)
            {


                throw sqlEx;
            }
            catch (System.Exception ex)
            {


                throw new Exception(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }

        public async Task<TEntity> SingleOrDefaultAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return await context.Set<TEntity>().SingleOrDefaultAsync(predicate);
        }

        /// <summary>
        /// Retourne une entrée de la table TEntity selon les critères passés en paramètres 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public TEntity First<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            string message = "Error";
            if (predicate == null)
                throw new ArgumentNullException(message);
            try
            {
                return GetQuery<TEntity>().Where(predicate).FirstOrDefault();
            }
            catch (ArgumentNullException argEx)
            {


                throw new ArgumentNullException(argEx.Message);
            }
            catch (SqlException sqlEx)
            {


                throw sqlEx;
            }
            catch (System.Exception ex)
            {


                throw new Exception(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }

        public async Task<TEntity> FirstAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return await context.Set<TEntity>().FirstAsync();
        }

        public async Task AddAsync<TEntity>(TEntity entity) where TEntity : class
        {
            try
            {
                context.Set<TEntity>().Add(entity);
                await context.SaveChangesAsync();
            }
            catch (ArgumentNullException argEx)
            {


                throw new ArgumentNullException(argEx.Message);
            }
            catch (SqlException sqlEx)
            {


                throw sqlEx;
            }
            catch (System.Exception ex)
            {


                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<int> CountAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            try
            {
                return await context.Set<TEntity>().CountAsync(predicate);
            }
            catch (ArgumentNullException argEx)
            {


                throw new ArgumentNullException(argEx.Message);
            }
            catch (SqlException sqlEx)
            {


                throw sqlEx;
            }
            catch (System.Exception ex)
            {


                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
        }


        /// <summary>
        /// Ajout d'une entrée à la table {entity}
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        public void Add<TEntity>(TEntity entity) where TEntity : class
        {
            string message = "Error";
            if (entity == null)
                throw new ArgumentNullException(message);

            try
            {
                //string baseEntityName = GetEntitySetName<TEntity>(entity);
                context.Entry(entity).State = System.Data.Entity.EntityState.Added;
            }
            catch (ArgumentNullException argEx)
            {


                throw new ArgumentNullException(argEx.Message);
            }
            catch (SqlException sqlEx)
            {


                throw sqlEx;
            }
            catch (System.Exception ex)
            {


                throw new Exception(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }

        /// <summary>
        /// Modification d'une entrée de la table {entity}
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <remarks></remarks>
        public void Update<TEntity>(TEntity entity) where TEntity : class
        {
            string message = "Error";
            if (entity == null)
                throw new ArgumentNullException(message);
            try
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            }
            catch (ArgumentNullException argEx)
            {


                throw new ArgumentNullException(argEx.Message);
            }
            catch (SqlException sqlEx)
            {


                throw sqlEx;
            }
            catch (System.Exception ex)
            {


                throw new Exception(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }

        }

        /// <summary>
        /// Supprime une entrée de la table entity
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        public void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            string message = "Error";
            if (entity == null)
                throw new ArgumentNullException(message);
            try
            {
                //context.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                context.Set<TEntity>().Remove(entity);
            }
            catch (ArgumentNullException argEx)
            {
                throw new ArgumentNullException(argEx.Message);
            }
            catch (SqlException sqlEx)
            {


                throw sqlEx;
            }
            catch (System.Exception ex)
            {


                throw new Exception(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }

        /// <summary>        
        /// Retourne le nom d'un objet entitée de type TEntity
        ///</summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <remarks>
        /// 07/07/2011 : Cette méthode est remplacée par GetEntitySetName<TEntity>(TEntity entity)  
        /// qui retourne dynamiquement le nom de l'entitySet.
        /// Raison : Le nom de l'entitySet ne correspond pas forcément au pluriel du nom de l'entity.
        /// </remarks>
        /// <returns></returns>
        [Obsolete]
        private string GetEntityName<TEntity>() where TEntity : class
        {
            return string.Format("Join2ShipEntities.{0}", pluralizer.Pluralize(typeof(TEntity).Name));

        }

        /// <summary>
        /// 
        /// Retourne  le nom de l'entity en fonction de son type
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <remarks>
        /// 07/07/2011 : Cette méthode est remplacée par GetEntitySetName<TEntity>(TEntity entity)  
        /// qui retourne dynamiquement le nom de l'entitySet
        /// Raison : Le nom de l'entitySet ne correspond pas forcément au pluriel du nom de l'entity.
        /// </remarks>
        /// <returns></returns>
        [Obsolete]
        private string GetEntityName<TEntity>(TEntity entity) where TEntity : class
        {
            string message = "Error";
            if (entity == null)
                throw new ArgumentNullException(message);
            try
            {
                return string.Format("Join2ShipEntities.{0}", pluralizer.Pluralize(entity.GetType().Name));
            }
            catch (ArgumentNullException)
            {
                throw new Exception(message);
            }

        }

        /// <summary>
        /// Sauvegarde  tous les changements après modification
        /// </summary>
        public void SaveChanges()
        { 
            context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

        public async Task<bool> AnyAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            try
            {
                return await context.Set<TEntity>().AnyAsync(predicate);
            }
            #region Exception
            catch (ArgumentNullException argEx)
            {




                throw new ArgumentNullException(argEx.Message);
            }
            catch (SqlException sqlEx)
            {




                throw sqlEx;
            }
            catch (DataException dEx)
            {
                throw new Exception(dEx.Message);
            }
            catch (System.Exception ex)
            {


                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
            #endregion Exception
        }


        /// <summary>
        /// Libère toutes les ressources
        /// </summary>
        public void Dispose()
        {
            try
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
            catch (System.Exception ex)
            {


                throw new Exception(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
        /// <summary>
        /// Libère toutes les ressources
        /// </summary>
        /// <param name="disposing">  true :  Libère toutes les ressources </param>
        protected virtual void Dispose(bool disposing)
        {
            string message = "";
            if (disposing)
            {
                if (context == null)
                    throw new ArgumentNullException(message);
                try
                {
                    context.Dispose();
                    context = null;
                }
                catch (ArgumentNullException)
                {
                    throw new Exception(message);
                }
            }
        }

        public void DeleteById(short id)
        {
            PERSON entity = (PERSON)context.People.Select(p => p.IDUSER == id);
            //context.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
            context.Set<PERSON>().Remove(entity);

        }
    }
}
