using System.Configuration;

namespace Sample.Repository.ADONET
{
    public abstract class BaseRepository
    {
        private string _connectionString;
        public string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }

        public BaseRepository()
        {
            this.ConnectionString = ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
        }
    }
}
