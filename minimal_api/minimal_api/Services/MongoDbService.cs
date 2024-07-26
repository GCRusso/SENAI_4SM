using MongoDB.Driver;

namespace minimal_api.Services
{
    public class MongoDbService
    {
        ///Armazena a configuracao da aplicacao
        private readonly IConfiguration _configuration;

        //Armazena uma referencia ao MongoDb
        private readonly IMongoDatabase _database;

        /// <summary>
        /// Recebe a configuracao da aplicacao como parametro
        /// </summary>
        /// <param name="configuration">Objeto configuration</param>
       
        public MongoDbService(IConfiguration configuration)
        {
            //Atribui a configuracao recebida em _configuration
            _configuration = configuration;

            //Obtem a string de conexao atraves do _configuration
            var ConnectionString = _configuration.GetConnectionString("DbConnection");

            //Cria um objeto MongoUrl
            var mongoUrl = MongoUrl.Create(ConnectionString);
            
            //Cria um client MongoClient para se conectar ao MongoDb
            var mongoClient = new MongoClient(mongoUrl);

            //Obtem a referencia ao banco de dados com o nome especificado na string de conexao
            _database = mongoClient.GetDatabase(mongoUrl.DatabaseName);
        }
        /// <summary>
        /// Propriedade para acessar o banco de dados
        /// Retorna a referencia ao BD
        /// </summary>
        public IMongoDatabase GetDatabase => _database;
    }
}
