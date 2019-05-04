using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MongoDB.Bson;
using MongoDB.Driver;
using RomanosApi.Infrastructure.Data;

namespace RomanosApi.Infrastructure.Repositories
{
    public class Repository<T> where T : class
    {
        IMongoCollection<T> collection;
        public Repository(string nameTable)
        {
            collection = new MongoDbConect().AbriConection().GetCollection<T>(nameTable);
        }

        public IEnumerable<T> Listar()
        {
            return collection.Find(_ => true).ToList();
        }

        public IEnumerable<T> Listar(Expression<Func<T, bool>> where)
        {
            IQueryable<T> consulta = collection.AsQueryable<T>();

            if (where != null)
            { consulta = consulta.Where(where); }

            return consulta.ToList();
        }

        public T Consultar(Expression<Func<T, bool>> where)
        {
            IQueryable<T> consulta = collection.AsQueryable<T>();

            if (where != null)
            { consulta = consulta.Where(where); }

            return consulta.FirstOrDefault();
        }

        public void Inserir(T obj)
        {

            collection.InsertOne(obj);
        }

        public void Atualizar(Expression<Func<T, bool>> where, T obj)
        {
            collection.ReplaceOne(where, obj);
        }

        public void Excluir(Expression<Func<T, bool>> where)
        {
            try
            {
                if (where != null)
                {
                    collection.DeleteOne(where);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
