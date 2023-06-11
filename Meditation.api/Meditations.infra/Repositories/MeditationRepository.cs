using System;
using Meditation.api.Meditations.infra.Configurations;
using Meditation.api.Models;
using Meditation.infra.Repositories;
using MongoDB.Driver;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Meditation.api.Meditation.infra.Repositories
{
    public class MeditationRepository : IMeditationRepository
    {
        private readonly IMongoCollection<MeditationClass> _meditacoesEs;
        private readonly IMongoCollection<MeditationClass> _meditacoesPt;

        public MeditationRepository(IDatabaseConfig databaseConfig)
        {
            var client = new MongoClient(databaseConfig.GetConnectionString());
            var database = client.GetDatabase(databaseConfig.GetDatabaseName());

            _meditacoesEs = database.GetCollection<MeditationClass>("meditacoesEs");
            _meditacoesPt = database.GetCollection<MeditationClass>("meditacoesPt");
        }


        public void Add(MeditationClass meditation)
        {
            _meditacoesPt.InsertOne(meditation);
        }

        public void Update(string id, MeditationClass meditation)
        {
            _meditacoesPt.ReplaceOne(meditation => meditation._id == id, meditation);
        }

        public IEnumerable<MeditationClass> FindMeditation()
        {
            return _meditacoesPt.Find(meditation => true).ToList();
        }
        public MeditationClass FindId(string id)
        {
            return _meditacoesPt.Find(meditation => meditation._id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _meditacoesPt.DeleteOne(meditation => meditation._id == id);
        }
    }
}

