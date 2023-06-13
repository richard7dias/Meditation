using System;
using MeditationEs.Domain;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MeditationEs.Infra
{
	public class MeditationsService
	{
        private readonly IMongoCollection<MeditationClass> _meditationsCollection;

        public MeditationsService(
            IOptions<MeditationsDatabaseSettings> meditationDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                meditationDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                meditationDatabaseSettings.Value.DatabaseName);

            _meditationsCollection = mongoDatabase.GetCollection<MeditationClass>(
                meditationDatabaseSettings.Value.MeditationsCollectionName);
        }

        public async Task<List<MeditationClass>> GetAsync() =>
            await _meditationsCollection.Find(_ => true).ToListAsync();

        public async Task<MeditationClass?> GetAsync(string id) =>
            await _meditationsCollection.Find(x => x._id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(MeditationClass newMeditation) =>
            await _meditationsCollection.InsertOneAsync(newMeditation);

        public async Task UpdateAsync(string id, MeditationClass updatedMeditation) =>
            await _meditationsCollection.ReplaceOneAsync(x => x._id == id, updatedMeditation);

        public async Task RemoveAsync(string id) =>
            await _meditationsCollection.DeleteOneAsync(x => x._id == id);
    }
}