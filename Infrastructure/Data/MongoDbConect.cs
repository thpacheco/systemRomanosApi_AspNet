using MongoDB.Driver;

namespace RomanosApi.Infrastructure.Data
{
    public class MongoDbConect
    {
        public IMongoDatabase AbriConection()
        {
            string stringConection = "mongodb://thpacheco:Thiago85@ds012889.mlab.com:12889/db_romanos";
            MongoClient client = new MongoClient(stringConection);
            return client.GetDatabase("db_romanos");
        }
    }
}
